using System;
using System.Windows.Forms;
using PrototypeMapEditor.EditorForm;

namespace PrototypeMapEditor
{
    public static class Program
    {

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var program = new Main())
            {
                Application.Run(program);
            }
        }
    }
}