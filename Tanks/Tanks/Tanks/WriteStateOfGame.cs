using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    class WriteStateOfGame
    {

        public async void WriteState(BindingList<IObjects> listOfObject)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.Title = "Save text Files";
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            string writePath = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                writePath = saveFileDialog1.FileName;
                var text = GetText(listOfObject);

                using (StreamWriter sw = new StreamWriter(writePath, false, Encoding.Unicode))
                {
                    await sw.WriteLineAsync(text.ToString());
                }
            }
        }

        public StringBuilder GetText(BindingList<IObjects> listOfObject)
        {

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < 400; i = i + 20)
            {
                for (int j = 0; j < 700; j = j + 20)
                {
                    var result = listOfObject.Count(p => p.CurrentPosition.X == i &&
                        p.CurrentPosition.Y == j);
                    var objects = listOfObject.Where(p => p.CurrentPosition.X == i &&
                        p.CurrentPosition.Y == j);
                    if (objects.Count() > 0 && objects.First() is Apple && result >= 1)
                        stringBuilder.Append('a');
                    else if (objects.Count() > 0 && objects.First() is Kolobok && result >= 1)
                        stringBuilder.Append('k');
                    else if (objects.Count() > 0 && objects.First() is Tank && result >= 1)
                        stringBuilder.Append('t');
                    else
                        stringBuilder.Append('-');
                }
                stringBuilder.Append('\n');
            }
            return stringBuilder;
        }
    }
}
