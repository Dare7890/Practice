using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    class WriteStateOfGame
    {

        public async void WriteState(BindingList<IObjects> listOfObject)
        {
            var text = GetText(listOfObject);
            string writePath = @"State.txt";

            using (StreamWriter sw = new StreamWriter(writePath, false, Encoding.Unicode))
            {
                await sw.WriteLineAsync(text.ToString());
            }
        }

        public StringBuilder GetText(BindingList<IObjects> listOfObject)
        {

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var objects in listOfObject)
            {
                for (int i = 0; i < 400; i = i + 20)
                {
                    for (int j = 0; j < 700; j = j + 20)
                    {
                        if (objects is Apple && objects.CurrentPosition.X == i &&
                            objects.CurrentPosition.Y == j)
                            stringBuilder.Append('a');
                        else if (objects is Kolobok && objects.CurrentPosition.X == i &&
                            objects.CurrentPosition.Y == j)
                            stringBuilder.Append('k');
                        else if (objects is Tank && objects.CurrentPosition.X == i &&
                            objects.CurrentPosition.Y == j)
                            stringBuilder.Append('t');
                        else
                            stringBuilder.Append('-');
                    }
                }
            }
            return stringBuilder;
        }
    }
}
