using Antlr4.Runtime.Misc;
using JetBrains.DataFlow;
using JetBrains.Lifetimes;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.Caches;
using JetBrains.ReSharper.Psi.Resolve;
using JetBrains.ReSharper.Psi.Tree;

namespace JetBrains.ReSharper.Plugins.Spring
{
    [ReferenceProviderFactory]
    public class SpringReferenceProvider : IReferenceProviderFactory
    {
        public SpringReferenceProvider(Lifetime lifetime)
        {
            Changed = new Signal<IReferenceProviderFactory>(lifetime, GetType().FullName);
        }

        public IReferenceFactory CreateFactory(IPsiSourceFile sourceFile, IFile file, IWordIndex wordIndexForChecks)
        {
            return sourceFile.PrimaryPsiLanguage.Is<SpringLanguage>() ? new SpringReferenceFactory() : null;
        }

        public ISignal<IReferenceProviderFactory> Changed { get; }
    }

    public class SpringReferenceFactory : IReferenceFactory
    {
        public ReferenceCollection GetReferences(ITreeNode element, ReferenceCollection oldReferences)
        {
            if (element is SpringVariableReferenceElement varReference)
            {
                return new ReferenceCollection(new ArrayList<IReference>{new SpringVariableReference(varReference)});
            }
            return ReferenceCollection.Empty;
        }

        public bool HasReference(ITreeNode element, IReferenceNameContainer names)
        {
            if (element is SpringVariableReferenceElement refElem)
            {
                string name = refElem.GetText();
                return names.Contains(name);    
            }

            return false;
        }
    }
}