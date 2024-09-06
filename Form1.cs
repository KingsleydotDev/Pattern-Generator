using System.Reflection.Metadata.Ecma335;

namespace Pattern_Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = GeneratePattern(textBox1.Text);
            }
            catch { }

        }

        string GeneratePattern(string input)
        {
            // get each line
            string[] lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            // list to hold out pattern
            List<string> convertedBytes = new List<string>();

            foreach (string line in lines)
            {
                // split into chunks and ignore the addess stuff
                string[] chunks = line.Split(" - ");

                // get bytes in string format and remove new line symbol
                string[] bytes = chunks[1].Replace("\r", "").Split(' ', StringSplitOptions.RemoveEmptyEntries);

                //loop thorugh bytes and replace potential address with wildcard

                for (int i = 0; i < bytes.Length; i++)
                {
                    if (bytes[i].Length == 8) // assuming addresses are 8 characters
                        convertedBytes.Add("?? ?? ?? ??");

                    else if (bytes[i] == "00")
                        convertedBytes.Add("??");

                    else
                    {
                        for (int j = 0; j < bytes[i].Length; j += 2)
                        {
                            convertedBytes.Add(bytes[i].Substring(j, 2));
                        }
                    }
                }
            }
            return String.Join(" ", convertedBytes.ToArray());
        }
    }
}
