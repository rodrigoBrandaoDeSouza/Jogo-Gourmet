using Microsoft.VisualBasic;

namespace JogoGourmet
{
    public partial class GuessAnDish : Form
    {
        private List<Dish> dishes;

        public GuessAnDish()
        {
            InitializeComponent();

            dishes = new List<Dish>()
            {
                new Dish("Lasanha", "Massa")
            };
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var list = dishes.Select(x => x.Type).Distinct(); 

            foreach (var dishType in dishes.Select(x => x.Type).Distinct())
            {
                var result = MessageBox.Show($"O prato que voce pensou � {dishType} ?",
                    "Confirma��o",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var dishFiltered = dishes
                        .Where(x => x.Type == dishType)
                        .Select(x => x.Name);


                    foreach (var dish in dishFiltered)
                    {
                        var gotIt = MessageBox.Show($"O prato que voce pensou � {dish} ?",
                            "Confirma��o",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                        
                        if(gotIt == DialogResult.Yes)
                        {
                            var goctha = MessageBox.Show("Acertei denovo", "Jogo Gourmet", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        if (gotIt == DialogResult.No)
                        {
                            continue;
                        }
                        
                    }
                    var newDish = Interaction.InputBox("Qual prato voce pensou?", "Desisto");

                    if (!string.IsNullOrEmpty(newDish))
                    {
                        var lasType = dishes.Select(x=>x.Type).Last();

                        var newType = Interaction.InputBox($"{newDish} � ______ mas n�o � {lasType} n�o.", "Confirma��o");

                        if (!string.IsNullOrEmpty(newDish))
                        {
                            dishes.Add(new Dish(newDish, newType));
                            break;
                        }
                        return;
                    }
                }

                else if (result == DialogResult.No)
                {
                    var last  = dishes.Select(x => x.Type).Distinct().Last();
                    
                    if (dishType != last)
                    {
                        continue;
                    }

                    var isCakeResult = MessageBox.Show($"O prato que voce pensou � bolo de chocolate? ?",
                       "Confirma��o",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (isCakeResult == DialogResult.Yes)
                    {
                        var goctha = MessageBox.Show("Acertei denovo", "Jogo Gourmet", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else if (isCakeResult == DialogResult.No)
                    {
                        var newDish = Interaction.InputBox("Qual prato voce pensou?", "Desisto");

                        if (!string.IsNullOrEmpty(newDish))
                        {
                            var newType = Interaction.InputBox($"{newDish} � ______ mas n�o � bolo de chocolate n�o.", "Confirma��o");

                            if (!string.IsNullOrEmpty(newDish))
                            {
                                dishes.Add(new Dish(newDish, newType));
                                break;
                            }
                            return;
                        }
                    }
                }
            }
        }
    }
}