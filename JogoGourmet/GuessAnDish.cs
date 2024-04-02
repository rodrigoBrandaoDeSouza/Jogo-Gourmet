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
                new Dish()
                {
                    Name = "Lasanha",
                    Type = "Massa",
                    Id = 2,
                    ParentId = 1,
                },
                 new Dish()
                {
                    Name = "Bolo de chocolate",
                    Type = "Bolo de chocolate",
                    Id = 1,
                    ParentId = 0,
                },
            };
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            GuessADish(1);
        }

        private bool HasAChild(int id)
        {
            return dishes.Where(x => x.ParentId == id).Any();
        }

        private void GuessADish(int parentId)
        {
            var filteredDishes = dishes.Where(x => x.ParentId == parentId);

            foreach (var dish in filteredDishes)
            {
                var result = MessageBox.Show($"O prato que voce pensou é {dish.Type} ?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (HasAChild(dish.Id))
                    {
                        GuessADish(dish.Id);
                        break;
                    }

                    var gotIt = MessageBox.Show($"O prato que voce pensou é {dish.Name} ?",
                           "Confirmação",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question);

                    if (gotIt == DialogResult.Yes)
                    {
                        Gotcha();
                    }

                    if (gotIt == DialogResult.No)
                    {
                        AddDish(dish.Id);
                        return;
                    }

                }
                if (result == DialogResult.No)
                {
                    if (dish != filteredDishes.Last())
                    {
                        continue;
                    }

                    var dishParent = dishes.Where(x => x.Id == dish.ParentId).FirstOrDefault();

                    var gotIt = MessageBox.Show($"O prato que voce pensou é {dishParent.Name} ?",
                          "Confirmação",
                          MessageBoxButtons.YesNo,
                          MessageBoxIcon.Question);

                    if (gotIt == DialogResult.Yes)
                    {
                        var goctha = MessageBox.Show("Acertei denovo", "Jogo Gourmet", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (gotIt == DialogResult.No)
                    {
                        AddDish(dish.ParentId);
                        return;
                    }
                }
            }
        }

        private static void Gotcha()
        {
            MessageBox.Show("Acertei de novo!", "Jogo Gourmet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private void AddDish(int parentId)
        {
            var newDish = Interaction.InputBox("Qual prato voce pensou?", "Desisto");

            if (!string.IsNullOrEmpty(newDish))
            {
                var lastName = dishes
                    .Where(x=>x.Id == parentId)
                    .Select(x => x.Name).Last();

                var newType = Interaction.InputBox($"{newDish} é ______ mas {lastName} não.", "Confirmação");

                if (!string.IsNullOrEmpty(newDish))
                {

                    dishes.Add(new Dish()
                    {
                        Name = newDish,
                        Type = newType,
                        Id = dishes.Count() + 1,
                        ParentId = parentId
                    });
                }
            }
        }
    }
}
