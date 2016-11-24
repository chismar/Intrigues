/*
 * DefParser.cs
 *
 * THIS FILE HAS BEEN GENERATED AUTOMATICALLY. DO NOT EDIT!
 */

using System.IO;

using PerCederberg.Grammatica.Runtime;

namespace InternalDSL {

    /**
     * <remarks>A token stream parser.</remarks>
     */
    internal class DefParser : RecursiveDescentParser {

        /**
         * <summary>An enumeration with the generated production node
         * identity constants.</summary>
         */
        private enum SynteticPatterns {
            SUBPRODUCTION_1 = 3001,
            SUBPRODUCTION_2 = 3002,
            SUBPRODUCTION_3 = 3003,
            SUBPRODUCTION_4 = 3004,
            SUBPRODUCTION_5 = 3005,
            SUBPRODUCTION_6 = 3006,
            SUBPRODUCTION_7 = 3007,
            SUBPRODUCTION_8 = 3008,
            SUBPRODUCTION_9 = 3009,
            SUBPRODUCTION_10 = 3010,
            SUBPRODUCTION_11 = 3011,
            SUBPRODUCTION_12 = 3012,
            SUBPRODUCTION_13 = 3013,
            SUBPRODUCTION_14 = 3014,
            SUBPRODUCTION_15 = 3015,
            SUBPRODUCTION_16 = 3016,
            SUBPRODUCTION_17 = 3017
        }

        /**
         * <summary>Creates a new parser with a default analyzer.</summary>
         *
         * <param name='input'>the input stream to read from</param>
         *
         * <exception cref='ParserCreationException'>if the parser
         * couldn't be initialized correctly</exception>
         */
        public DefParser(TextReader input)
            : base(input) {

            CreatePatterns();
        }

        /**
         * <summary>Creates a new parser.</summary>
         *
         * <param name='input'>the input stream to read from</param>
         *
         * <param name='analyzer'>the analyzer to parse with</param>
         *
         * <exception cref='ParserCreationException'>if the parser
         * couldn't be initialized correctly</exception>
         */
        public DefParser(TextReader input, DefAnalyzer analyzer)
            : base(input, analyzer) {

            CreatePatterns();
        }

        /**
         * <summary>Creates a new tokenizer for this parser. Can be overridden
         * by a subclass to provide a custom implementation.</summary>
         *
         * <param name='input'>the input stream to read from</param>
         *
         * <returns>the tokenizer created</returns>
         *
         * <exception cref='ParserCreationException'>if the tokenizer
         * couldn't be initialized correctly</exception>
         */
        protected override Tokenizer NewTokenizer(TextReader input) {
            return new DefTokenizer(input);
        }

        /**
         * <summary>Initializes the parser by creating all the production
         * patterns.</summary>
         *
         * <exception cref='ParserCreationException'>if the parser
         * couldn't be initialized correctly</exception>
         */
        private void CreatePatterns() {
            ProductionPattern             pattern;
            ProductionPatternAlternative  alt;

            pattern = new ProductionPattern((int) DefConstants.ROOT,
                                            "Root");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) DefConstants.OPERATOR, 1, -1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) DefConstants.SCOPE,
                                            "Scope");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) DefConstants.IDENTIFIER_OR_CALL, 1, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_1, 0, -1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) DefConstants.FUNC_SCOPE,
                                            "FuncScope");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DefConstants.IDENTIFIER, 1, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_2, 0, -1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) DefConstants.IDENTIFIER_OR_CALL,
                                            "IdentifierOrCall");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DefConstants.IDENTIFIER, 1, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_3, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) DefConstants.CALL_ARGS,
                                            "CallArgs");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) DefConstants.EXPRESSION, 1, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_4, 0, -1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) DefConstants.OPERATOR,
                                            "Operator");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) DefConstants.SCOPE, 1, 1);
            alt.AddToken((int) DefConstants.EQUALS, 1, 1);
            alt.AddProduction((int) DefConstants.CONTEXT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) DefConstants.CONTEXT,
                                            "Context");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DefConstants.OPEN_TABLE, 1, 1);
            alt.AddProduction((int) DefConstants.LIST, 1, 1);
            alt.AddToken((int) DefConstants.CLOSE_TABLE, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) DefConstants.EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) DefConstants.LIST,
                                            "List");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_6, 1, -1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) DefConstants.DECIMAL,
                                            "Decimal");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DefConstants.NUMBER, 1, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_8, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) DefConstants.ATOM,
                                            "Atom");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) DefConstants.DECIMAL, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DefConstants.TRUE, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DefConstants.FALSE, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DefConstants.STRING, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) DefConstants.FACTOR,
                                            "Factor");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_9, 0, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_11, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) DefConstants.MUL_TERM,
                                            "MulTerm");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) DefConstants.FACTOR, 1, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_12, 0, -1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) DefConstants.ADD_TERM,
                                            "AddTerm");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) DefConstants.MUL_TERM, 1, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_13, 0, -1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) DefConstants.RELATE_TERM,
                                            "RelateTerm");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) DefConstants.ADD_TERM, 1, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_14, 0, -1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) DefConstants.EQ_TERM,
                                            "EqTerm");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) DefConstants.RELATE_TERM, 1, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_15, 0, -1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) DefConstants.AND_TERM,
                                            "AndTerm");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) DefConstants.EQ_TERM, 1, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_16, 0, -1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) DefConstants.OR_TERM,
                                            "OrTerm");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) DefConstants.AND_TERM, 1, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_17, 0, -1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) DefConstants.EXPRESSION,
                                            "Expression");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) DefConstants.OR_TERM, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_1,
                                            "Subproduction1");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DefConstants.DOT, 1, 1);
            alt.AddProduction((int) DefConstants.IDENTIFIER_OR_CALL, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_2,
                                            "Subproduction2");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DefConstants.DOT, 1, 1);
            alt.AddToken((int) DefConstants.IDENTIFIER, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_3,
                                            "Subproduction3");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DefConstants.OPEN_PARENT, 1, 1);
            alt.AddProduction((int) DefConstants.CALL_ARGS, 0, 1);
            alt.AddToken((int) DefConstants.CLOSE_PARENT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_4,
                                            "Subproduction4");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DefConstants.DELIMITER, 1, 1);
            alt.AddProduction((int) DefConstants.EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_5,
                                            "Subproduction5");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DefConstants.EQUALS, 1, 1);
            alt.AddProduction((int) DefConstants.CONTEXT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_6,
                                            "Subproduction6");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) DefConstants.SCOPE, 1, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_5, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) DefConstants.ATOM, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DefConstants.OPEN_TABLE, 1, 1);
            alt.AddProduction((int) DefConstants.LIST, 1, 1);
            alt.AddToken((int) DefConstants.CLOSE_TABLE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_7,
                                            "Subproduction7");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DefConstants.NUMBEREND, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DefConstants.NUMBER, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_8,
                                            "Subproduction8");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DefConstants.DOT, 1, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_7, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_9,
                                            "Subproduction9");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DefConstants.SUB, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DefConstants.NOT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_10,
                                            "Subproduction10");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) DefConstants.ATOM, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) DefConstants.SCOPE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_11,
                                            "Subproduction11");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_10, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DefConstants.OPEN_PARENT, 1, 1);
            alt.AddProduction((int) DefConstants.EXPRESSION, 1, 1);
            alt.AddToken((int) DefConstants.CLOSE_PARENT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_12,
                                            "Subproduction12");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DefConstants.MUL, 1, 1);
            alt.AddProduction((int) DefConstants.FACTOR, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DefConstants.DIV, 1, 1);
            alt.AddProduction((int) DefConstants.FACTOR, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_13,
                                            "Subproduction13");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DefConstants.ADD, 1, 1);
            alt.AddProduction((int) DefConstants.MUL_TERM, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DefConstants.SUB, 1, 1);
            alt.AddProduction((int) DefConstants.MUL_TERM, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_14,
                                            "Subproduction14");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DefConstants.MORE, 1, 1);
            alt.AddProduction((int) DefConstants.ADD_TERM, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DefConstants.LESS, 1, 1);
            alt.AddProduction((int) DefConstants.ADD_TERM, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DefConstants.MOREOREQUALS, 1, 1);
            alt.AddProduction((int) DefConstants.ADD_TERM, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DefConstants.LESSOREQUALS, 1, 1);
            alt.AddProduction((int) DefConstants.ADD_TERM, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_15,
                                            "Subproduction15");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DefConstants.EQUALS, 1, 1);
            alt.AddProduction((int) DefConstants.RELATE_TERM, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_16,
                                            "Subproduction16");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DefConstants.AND, 1, 1);
            alt.AddProduction((int) DefConstants.EQ_TERM, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_17,
                                            "Subproduction17");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DefConstants.OR, 1, 1);
            alt.AddProduction((int) DefConstants.AND_TERM, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);
        }
    }
}
