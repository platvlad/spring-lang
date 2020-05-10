using System;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.ExtensionsAPI.Tree;
using JetBrains.ReSharper.Psi.Parsing;
using JetBrains.Text;
using JetBrains.Util;

namespace JetBrains.ReSharper.Plugins.Spring
{
    class SpringTokenType : TokenNodeType
    {
        public static  SpringTokenType EQ = new SpringTokenType("EQ", 0);
        public static  SpringTokenType NUMBER = new SpringTokenType("NUMBER", 1);
        public static SpringTokenType STRING = new SpringTokenType("STRING", 2);
        public static SpringTokenType BAD_CHARACTER = new SpringTokenType("BAD_CHARACTER", 3);
        
                public static SpringTokenType T__0 = new SpringTokenType("T__0", 1);
        public static SpringTokenType T__1 = new SpringTokenType("T__1", 2);
        public static SpringTokenType T__2 = new SpringTokenType("T__2", 3);
        public static SpringTokenType T__3 = new SpringTokenType("T__3", 4);
        public static SpringTokenType T__4 = new SpringTokenType("T__4", 5);
        public static SpringTokenType T__5 = new SpringTokenType("T__5", 6);
        public static SpringTokenType T__6 = new SpringTokenType("T__6", 7);
        public static SpringTokenType T__7 = new SpringTokenType("T__7", 8);
        public static SpringTokenType T__8 = new SpringTokenType("T__8", 9);
        public static SpringTokenType T__9 = new SpringTokenType("T__9", 10);
        public static SpringTokenType T__10 = new SpringTokenType("T__10", 11);
        public static SpringTokenType T__11 = new SpringTokenType("T__11", 12);
        public static SpringTokenType T__12 = new SpringTokenType("T__12", 13);
        public static SpringTokenType T__13 = new SpringTokenType("T__13", 14);
        public static SpringTokenType Auto = new SpringTokenType("Auto", 15);
        public static SpringTokenType Break = new SpringTokenType("Break", 16);
        public static SpringTokenType Case = new SpringTokenType("Case", 17);
        public static SpringTokenType Char = new SpringTokenType("Char", 18);
        public static SpringTokenType Const = new SpringTokenType("Const", 19);
        public static SpringTokenType Continue = new SpringTokenType("Continue", 20);
        public static SpringTokenType Default = new SpringTokenType("Default", 21);
        public static SpringTokenType Do = new SpringTokenType("Do", 22);
        public static SpringTokenType Double = new SpringTokenType("Double", 23);
        public static SpringTokenType Else = new SpringTokenType("Else", 24);
        public static SpringTokenType Enum = new SpringTokenType("Enum", 25);
        public static SpringTokenType Extern = new SpringTokenType("Extern", 26);
        public static SpringTokenType Float = new SpringTokenType("Float", 27);
        public static SpringTokenType For = new SpringTokenType("For", 28);
        public static SpringTokenType Goto = new SpringTokenType("Goto", 29);
        public static SpringTokenType If = new SpringTokenType("If", 30);
        public static SpringTokenType Inline = new SpringTokenType("Inline", 31);
        public static SpringTokenType Int = new SpringTokenType("Int", 32);
        public static SpringTokenType Long = new SpringTokenType("Long", 33);
        public static SpringTokenType Register = new SpringTokenType("Register", 34);
        public static SpringTokenType Restrict = new SpringTokenType("Restrict", 35);
        public static SpringTokenType Return = new SpringTokenType("Return", 36);
        public static SpringTokenType Short = new SpringTokenType("Short", 37);
        public static SpringTokenType Signed = new SpringTokenType("Signed", 38);
        public static SpringTokenType Sizeof = new SpringTokenType("Sizeof", 39);
        public static SpringTokenType Static = new SpringTokenType("Static", 40);
        public static SpringTokenType Struct = new SpringTokenType("Struct", 41);
        public static SpringTokenType Switch = new SpringTokenType("Switch", 42);
        public static SpringTokenType Typedef = new SpringTokenType("Typedef", 43);
        public static SpringTokenType Union = new SpringTokenType("Union", 44);
        public static SpringTokenType Unsigned = new SpringTokenType("Unsigned", 45);
        public static SpringTokenType Void = new SpringTokenType("Void", 46);
        public static SpringTokenType Volatile = new SpringTokenType("Volatile", 47);
        public static SpringTokenType While = new SpringTokenType("While", 48);
        public static SpringTokenType Alignas = new SpringTokenType("Alignas", 49);
        public static SpringTokenType Alignof = new SpringTokenType("Alignof", 50);
        public static SpringTokenType Atomic = new SpringTokenType("Atomic", 51);
        public static SpringTokenType Bool = new SpringTokenType("Bool", 52);
        public static SpringTokenType Complex = new SpringTokenType("Complex", 53);
        public static SpringTokenType Generic = new SpringTokenType("Generic", 54);
        public static SpringTokenType Imaginary = new SpringTokenType("Imaginary", 55);
        public static SpringTokenType Noreturn = new SpringTokenType("Noreturn", 56);
        public static SpringTokenType StaticAssert = new SpringTokenType("StaticAssert", 57);
        public static SpringTokenType ThreadLocal = new SpringTokenType("ThreadLocal", 58);
        public static SpringTokenType LeftParen = new SpringTokenType("LeftParen", 59);
        public static SpringTokenType RightParen = new SpringTokenType("RightParen", 60);
        public static SpringTokenType LeftBracket = new SpringTokenType("LeftBracket", 61);
        public static SpringTokenType RightBracket = new SpringTokenType("RightBracket", 62);
        public static SpringTokenType LeftBrace = new SpringTokenType("LeftBrace", 63);
        public static SpringTokenType RightBrace = new SpringTokenType("RightBrace", 64);
        public static SpringTokenType Less = new SpringTokenType("Less", 65);
        public static SpringTokenType LessEqual = new SpringTokenType("LessEqual", 66);
        public static SpringTokenType Greater = new SpringTokenType("Greater", 67);
        public static SpringTokenType GreaterEqual = new SpringTokenType("GreaterEqual", 68);
        public static SpringTokenType LeftShift = new SpringTokenType("LeftShift", 69);
        public static SpringTokenType RightShift = new SpringTokenType("RightShift", 70);
        public static SpringTokenType Plus = new SpringTokenType("Plus", 71);
        public static SpringTokenType PlusPlus = new SpringTokenType("PlusPlus", 72);
        public static SpringTokenType Minus = new SpringTokenType("Minus", 73);
        public static SpringTokenType MinusMinus = new SpringTokenType("MinusMinus", 74);
        public static SpringTokenType Star = new SpringTokenType("Star", 75);
        public static SpringTokenType Div = new SpringTokenType("Div", 76);
        public static SpringTokenType Mod = new SpringTokenType("Mod", 77);
        public static SpringTokenType And = new SpringTokenType("And", 78);
        public static SpringTokenType Or = new SpringTokenType("Or", 79);
        public static SpringTokenType AndAnd = new SpringTokenType("AndAnd", 80);
        public static SpringTokenType OrOr = new SpringTokenType("OrOr", 81);
        public static SpringTokenType Caret = new SpringTokenType("Caret", 82);
        public static SpringTokenType Not = new SpringTokenType("Not", 83);
        public static SpringTokenType Tilde = new SpringTokenType("Tilde", 84);
        public static SpringTokenType Question = new SpringTokenType("Question", 85);
        public static SpringTokenType Colon = new SpringTokenType("Colon", 86);
        public static SpringTokenType Semi = new SpringTokenType("Semi", 87);
        public static SpringTokenType Comma = new SpringTokenType("Comma", 88);
        public static SpringTokenType Assign = new SpringTokenType("Assign", 89);
        public static SpringTokenType StarAssign = new SpringTokenType("StarAssign", 90);
        public static SpringTokenType DivAssign = new SpringTokenType("DivAssign", 91);
        public static SpringTokenType ModAssign = new SpringTokenType("ModAssign", 92);
        public static SpringTokenType PlusAssign = new SpringTokenType("PlusAssign", 93);
        public static SpringTokenType MinusAssign = new SpringTokenType("MinusAssign", 94);
        public static SpringTokenType LeftShiftAssign = new SpringTokenType("LeftShiftAssign", 95);
        public static SpringTokenType RightShiftAssign = new SpringTokenType("RightShiftAssign", 96);
        public static SpringTokenType AndAssign = new SpringTokenType("AndAssign", 97);
        public static SpringTokenType XorAssign = new SpringTokenType("XorAssign", 98);
        public static SpringTokenType OrAssign = new SpringTokenType("OrAssign", 99);
        public static SpringTokenType Equal = new SpringTokenType("Equal", 100);
        public static SpringTokenType NotEqual = new SpringTokenType("NotEqual", 101);
        public static SpringTokenType Arrow = new SpringTokenType("Arrow", 102);
        public static SpringTokenType Dot = new SpringTokenType("Dot", 103);
        public static SpringTokenType Ellipsis = new SpringTokenType("Ellipsis", 104);
        public static SpringTokenType Identifier = new SpringTokenType("Identifier", 105);
        public static SpringTokenType Constant = new SpringTokenType("Constant", 106);
        public static SpringTokenType DigitSequence = new SpringTokenType("DigitSequence", 107);
        public static SpringTokenType StringLiteral = new SpringTokenType("StringLiteral", 108);
        public static SpringTokenType ComplexDefine = new SpringTokenType("ComplexDefine", 109);
        public static SpringTokenType IncludeDirective = new SpringTokenType("IncludeDirective", 110);
        public static SpringTokenType AsmBlock = new SpringTokenType("AsmBlock", 111);
        public static SpringTokenType LineAfterPreprocessing = new SpringTokenType("LineAfterPreprocessing", 112);
        public static SpringTokenType LineDirective = new SpringTokenType("LineDirective", 113);
        public static SpringTokenType PragmaDirective = new SpringTokenType("PragmaDirective", 114);
        public static SpringTokenType Whitespace = new SpringTokenType("Whitespace", 115);
        public static SpringTokenType Newline = new SpringTokenType("Newline", 116);
        public static SpringTokenType BlockComment = new SpringTokenType("BlockComment", 117);
        public static SpringTokenType LineComment = new SpringTokenType("LineComment", 118);
        public static SpringTokenType UNKNOWN = new SpringTokenType("UNKNOWN", 119);
        
        public static SpringTokenType[] SpringTokenTypes =
        {
            null,
            T__0,
            T__1,
            T__2,
            T__3,
            T__4,
            T__5,
            T__6,
            T__7,
            T__8,
            T__9,
            T__10,
            T__11,
            T__12,
            T__13,
            Auto,
            Break,
            Case,
            Char,
            Const,
            Continue,
            Default,
            Do,
            Double,
            Else,
            Enum,
            Extern,
            Float,
            For,
            Goto,
            If,
            Inline,
            Int,
            Long,
            Register,
            Restrict,
            Return,
            Short,
            Signed,
            Sizeof,
            Static,
            Struct,
            Switch,
            Typedef,
            Union,
            Unsigned,
            Void,
            Volatile,
            While,
            Alignas,
            Alignof,
            Atomic,
            Bool,
            Complex,
            Generic,
            Imaginary,
            Noreturn,
            StaticAssert,
            ThreadLocal,
            LeftParen,
            RightParen,
            LeftBracket,
            RightBracket,
            LeftBrace,
            RightBrace,
            Less,
            LessEqual,
            Greater,
            GreaterEqual,
            LeftShift,
            RightShift,
            Plus,
            PlusPlus,
            Minus,
            MinusMinus,
            Star,
            Div,
            Mod,
            And,
            Or,
            AndAnd,
            OrOr,
            Caret,
            Not,
            Tilde,
            Question,
            Colon,
            Semi,
            Comma,
            Assign,
            StarAssign,
            DivAssign,
            ModAssign,
            PlusAssign,
            MinusAssign,
            LeftShiftAssign,
            RightShiftAssign,
            AndAssign,
            XorAssign,
            OrAssign,
            Equal,
            NotEqual,
            Arrow,
            Dot,
            Ellipsis,
            Identifier,
            Constant,
            DigitSequence,
            StringLiteral,
            ComplexDefine,
            IncludeDirective,
            AsmBlock,
            LineAfterPreprocessing,
            LineDirective,
            PragmaDirective,
            Whitespace,
            Newline,
            BlockComment,
            LineComment,
            UNKNOWN 
        };

        public SpringTokenType(string s, int index) : base(s, index)
        {
            TokenRepresentation = s;
        }

        public override LeafElementBase Create(IBuffer buffer, TreeOffset startOffset, TreeOffset endOffset)
        {
            return new CLeafElement(buffer.GetText(new TextRange(startOffset.Offset, endOffset.Offset)), this);
        }

        public override bool IsWhitespace => TokenRepresentation == "Whitespace" || TokenRepresentation == "Newline";
        public override bool IsComment => String.Compare("LineComment", TokenRepresentation, StringComparison.Ordinal) == 0 || 
                                          String.Compare("BlockComment", TokenRepresentation, StringComparison.Ordinal) == 0;
        public override bool IsStringLiteral => TokenRepresentation == "StringLiteral";
        public override bool IsConstantLiteral => TokenRepresentation == "Constant" || TokenRepresentation == "DigitSequence";
        public override bool IsIdentifier => TokenRepresentation == "Identifier";
        public override bool IsKeyword => Index > 14 && Index < 49;
        public override string TokenRepresentation { get; }
    }
}