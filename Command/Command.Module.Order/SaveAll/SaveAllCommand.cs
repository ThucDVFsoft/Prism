using Microsoft.Practices.Prism.Commands;

namespace Command.Module.Order.SaveAll
{
    public static class SaveAllCommand
    {
        public static CompositeCommand SaveAllCmd = new CompositeCommand();
    }

    public class SaveAllCommandProxy
    {
        public virtual CompositeCommand SaveAllCmd
        {
            get { return SaveAllCommand.SaveAllCmd; }
        }
    }
}
