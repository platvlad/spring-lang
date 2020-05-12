using System.Collections;
using System.Collections.Generic;
using System.Xml;
using ICSharpCode.NRefactory;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.Util.DataStructures;

namespace JetBrains.ReSharper.Plugins.Spring
{
    public class CVariableDeclared : IDeclaredElement
    {
        private IDeclaration declaration;
        
        public CVariableDeclared(IDeclaration declaration)
        {
            this.declaration = declaration;
        }

        public bool CaseSensitiveName => true;

        public IList<IDeclaration> GetDeclarations()
        {
            IList<IDeclaration> declList = new List<IDeclaration>();
            declList.Add(declaration);
            return declList;
        }

        public IList<IDeclaration> GetDeclarationsIn(IPsiSourceFile sourceFile)
        {
            if (sourceFile == declaration.GetSourceFile())
            {
                return GetDeclarations();
            }
            return EmptyList<IDeclaration>.Instance;
        }

        public DeclaredElementType GetElementType() => CLRDeclaredElementType.LOCAL_VARIABLE;

        public IPsiServices GetPsiServices() => declaration.GetPsiServices();

        public HybridCollection<IPsiSourceFile> GetSourceFiles()
        {
            IPsiSourceFile declFile = declaration.GetSourceFile();
            if (declFile != null)
            {
                return new HybridCollection<IPsiSourceFile>(declFile);
            }
            return HybridCollection<IPsiSourceFile>.Empty;
        }

        public XmlNode GetXMLDescriptionSummary(bool inherit)
        {
            return null;
        }

        public XmlNode GetXMLDoc(bool inherit) => null;

        public bool HasDeclarationsIn(IPsiSourceFile sourceFile) => 
            sourceFile == declaration.GetSourceFile();

        public bool IsSynthetic() => declaration.IsSynthetic();

        public bool IsValid() => declaration.IsValid();

        public PsiLanguageType PresentationLanguage => declaration.Language;

        public string ShortName => declaration.GetText();
    }
}