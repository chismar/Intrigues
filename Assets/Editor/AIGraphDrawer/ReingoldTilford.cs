using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.Director;

namespace AIVisualizer
{

    public static class PlayableExt
    {
        public static Playable[] GetInputs(this Playable playable)
        {
            Playable[] pls = new Playable[playable.handle.inputCount];
            for (int i = 0; i < playable.handle.inputCount; i++)
                pls[i] = playable.handle.GetInput(i).GetObject(); return pls;
        }
    }

    // Implementation of Reingold and Tilford algorithm for graph layout
    // "Tidier Drawings of Trees", IEEE Transactions on Software Engineering Vol SE-7 No.2, March 1981
    
    public class ReingoldTilford : ILayoutAlgorithm
    {
        public AIObject root
        {
            get
            {
                return m_Root;
            }
        }

        public List<Vertex> vertices
        {
            get
            {
                return m_Vertices;
            }
        }

        public List<Edge> edges
        {
            get
            {
                return m_Edges;
            }
        }

        private class NodeInfo
        {
            public AIObject playable;
            public int      depth;
            public int      vertexId;
            public Vector2  position;
            public float    weight;
            public float    propagatedWeight;

            public List<AIObject> children { get { return playable.GetConnections(); } }
        }

        // by convention, all graph layout algorithms should have a minimum distance of 1 unit between nodes
        const float k_DistanceBetweenNodes = 1;

        // used to lengthen the wire when lots of children are connected. If 1, all levels will be evenly separated
        const float k_WireLengthFactorForLargeSpanningTrees = 3;

        // working data of the algorithm
        Dictionary<AIObject, NodeInfo> m_Nodes = new Dictionary<AIObject, NodeInfo>();

        // tree root
        AIObject m_Root;

        // precomputed horizontal position for all nodes, which depends on node with the largest number of
        // children on that level
        float[] m_HorizontalPositionForLevel;

        // precomputed tree depth
        int m_TreeMaxDepth;

        // optimized data structures for rendering
        List<Vertex> m_Vertices;
        List<Edge> m_Edges;


        // Main entry point of the algorithm
        public void Layout(AIObject root)
        {
            m_Root = root;
            if (m_Nodes.Any())
            {
                Clear();
            }
            if (root == null)
                return;
            RecursiveAddNodes(root, 0, 1.0f, 1.0f);

            ComputeHorizontalPositionForEachLevel();
            RecursiveTraverse(root);
            UpdateVerticesAndEdgesForRendering();
        }

        // Reset all internal data
        private void Clear()
        {
            m_Nodes.Clear();
            m_TreeMaxDepth = 0;
        }

        // Synch internal data structure with the simplified public one
        private void UpdateVerticesAndEdgesForRendering()
        {
            if (m_Nodes.Keys.Count == 0)
                return;

            m_Vertices = new List<Vertex>();
            for (int i = 0; i < m_Nodes.Keys.Count;i++)
                m_Vertices.Add(null);

            var edgesList = new List<Edge>();
            foreach (var pair in m_Nodes)
            {
                NodeInfo info = pair.Value;

                m_Vertices[info.vertexId] = new Vertex
                {
                    position = info.position,
                    payload = info.playable,
                    weight = info.weight,
                    propagatedWeight = info.propagatedWeight
                };

                int nbChildren = pair.Value.children.Count;
                for (int i = 0; i < nbChildren; i++)
                {
                    AIObject c = pair.Value.children[i];
                    if (c != null)
                    {
                        edgesList.Add(new Edge(m_Nodes[c].vertexId, info.vertexId));
                    }
                }
            }
            m_Edges = edgesList;
        }

        // First pass to identify the nodes, and place them at a default initial position
        private void RecursiveAddNodes(AIObject node, int currentDepth, float weight, float parentWeight)
        {
            NodeInfo info = new NodeInfo();
            info.playable = node;
            info.weight = weight;
            info.propagatedWeight = weight * parentWeight;
            info.depth = currentDepth;

            if (currentDepth > m_TreeMaxDepth)
                m_TreeMaxDepth = currentDepth;

            // Assign vertex ID right away for ease of debugging
            info.vertexId = m_Nodes.Keys.Count;
            m_Nodes.Add(node, info);

            var inputs = node.GetConnections();
            int nbInputs = inputs.Count;

            for (int c = 0; c < nbInputs; c++)
            {
                if(inputs[c] != null)
                    RecursiveAddNodes(inputs[c], currentDepth + 1, 1f, weight * parentWeight);
            }
        }

        // Precompute the horizontal position for each level.
        // Levels with few wires (as measured by the maximum number of children for one node) are placed closer
        // apart; very cluttered levels are placed further apart.
        private void ComputeHorizontalPositionForEachLevel()
        {
            m_HorizontalPositionForLevel = new float[m_TreeMaxDepth + 1];
            m_HorizontalPositionForLevel[m_TreeMaxDepth] = 0;
            for (int d = m_TreeMaxDepth - 1; d >= 0; d--)
            {
                List<NodeInfo> nodesOnThisLevel = m_Nodes.Values
                    .Where(x => x.depth == d)
                    .ToList();

                int maxChildren = nodesOnThisLevel.Max(x => x.playable.GetConnections().Count);

                const float k_MaxChildrenThreshold = 6.0f;
                float wireLengthHeuristic = Mathf.Lerp(1, k_WireLengthFactorForLargeSpanningTrees,
                        Mathf.Min(1, (float)maxChildren / k_MaxChildrenThreshold));

                m_HorizontalPositionForLevel[d] = m_HorizontalPositionForLevel[d + 1] +
                    k_DistanceBetweenNodes * wireLengthHeuristic;
            }
        }

        // Traverse the graph and place all nodes according to the algorithm
        private void RecursiveTraverse(AIObject root)
        {
            foreach (var c in root.GetConnections())
            {
                if(c != null)
                {
                    RecursiveTraverse(c);
                }
            }

            Vector2 nodePos = new Vector2(m_HorizontalPositionForLevel[m_Nodes[root].depth], 0);

            // Move children apart until they stop touching
            
            var nonNullInputs = root.GetConnections().Where(x => x != null).ToArray();
            if (nonNullInputs.Length > 1)
            {
                SeparateSubtrees(nonNullInputs);
            }
            if (nonNullInputs.Length > 0)
            {
                nodePos.y = GetAveragePosition(nonNullInputs).y;
            }
            m_Nodes[root].position = nodePos;
        }

        // Determine parent's vertical position based on its children
        private Vector2 GetAveragePosition(AIObject[] nodes)
        {
            Vector2 centroid = new Vector2();

            foreach (var n in nodes)
            {
                centroid += m_Nodes[n].position;
            }
            if (nodes.Length > 0)
                centroid /= nodes.Length;
            return centroid;
        }

        // Separate the given subtrees so they do not overlap
        private void SeparateSubtrees(AIObject[] subroots)
        {
            subroots = subroots.Where(s => s != null).ToArray();
            if (subroots.Length < 2)
                return;

            AIObject upperNode = subroots[0];

            Dictionary<int, Vector2> upperTreeBoundaries = GetBoundaryPositions(upperNode);
            for (int s = 0; s < subroots.Length - 1; s++)
            {
                AIObject lowerNode = subroots[s + 1];
                Dictionary<int, Vector2> lowerTreeBoundaries = GetBoundaryPositions(lowerNode);

                int minDepth = upperTreeBoundaries.Keys.Min();
                if (minDepth != lowerTreeBoundaries.Keys.Min())
                    Debug.LogError("Cannot separate subtrees which do not start at the same root depth");

                int lowerMaxDepth = lowerTreeBoundaries.Keys.Max();
                int upperMaxDepth = upperTreeBoundaries.Keys.Max();
                int maxDepth = System.Math.Min(upperMaxDepth, lowerMaxDepth);

                for (int depth = minDepth; depth <= maxDepth; depth++)
                {
                    float delta = k_DistanceBetweenNodes - (lowerTreeBoundaries[depth].x - upperTreeBoundaries[depth].y);
                    delta = System.Math.Max(delta, 0);
                    RecursiveMoveSubtree(lowerNode, delta);
                    for (int i = minDepth; i <= lowerMaxDepth; i++)
                        lowerTreeBoundaries[i] += new Vector2(delta, delta);
                }
                upperTreeBoundaries = CombineBoundaryPositions(upperTreeBoundaries, lowerTreeBoundaries);
            }
        }

        // Using a Vector2 at each depth to hold the extrema vertical positions
        private Dictionary<int, Vector2> GetBoundaryPositions(AIObject subTreeRoot)
        {
            var extremePositions = new Dictionary<int, Vector2>();

            List<AIObject> descendants = GetSubtreeNodes(subTreeRoot);

            foreach (var node in descendants)
            {
                int depth = m_Nodes[node].depth;
                float pos =  m_Nodes[node].position.y;
                if (extremePositions.ContainsKey(depth))
                    extremePositions[depth] = new Vector2(Mathf.Min(extremePositions[depth].x, pos),
                            Mathf.Max(extremePositions[depth].y, pos));
                else
                    extremePositions[depth] = new Vector2(pos, pos);
            }

            return extremePositions;
        }

        // Includes all descendants and the subtree root itself
        private List<AIObject> GetSubtreeNodes(AIObject root)
        {
            var allDescendants = new List<AIObject>();
            allDescendants.Add(root);
            foreach (var child in root.GetConnections())
            {
                    allDescendants.AddRange(GetSubtreeNodes(child));
            }
            return allDescendants;
        }

        // After adjusting a subtree, compute its new boundary positions
        private Dictionary<int, Vector2> CombineBoundaryPositions(Dictionary<int, Vector2> upperTree, Dictionary<int, Vector2> lowerTree)
        {
            var combined = new Dictionary<int, Vector2>();
            int minDepth = upperTree.Keys.Min();
            int maxDepth = System.Math.Max(upperTree.Keys.Max(), lowerTree.Keys.Max());

            for (int d = minDepth; d <= maxDepth; d++)
            {
                float upperBoundary = upperTree.ContainsKey(d) ? upperTree[d].x : lowerTree[d].x;
                float lowerBoundary = lowerTree.ContainsKey(d) ? lowerTree[d].y : upperTree[d].y;
                combined[d] = new Vector2(upperBoundary, lowerBoundary);
            }
            return combined;
        }

        // Apply a vertical delta to all nodes in a subtree
        private void RecursiveMoveSubtree(AIObject subtreeRoot, float delta)
        {
            m_Nodes[subtreeRoot].position.y += delta;

            foreach (var child in subtreeRoot.GetConnections())
            {
                    RecursiveMoveSubtree(child, delta);
            }
        }
    }
}
