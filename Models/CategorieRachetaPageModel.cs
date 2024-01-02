using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_MDP_Web.Data;

namespace Proiect_MDP_Web.Models
{
    public class CategorieRachetaPageModel: PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;

        public void PopulateAssignedCategoryData(Proiect_MDP_WebContext context, Racheta racheta)
        {
            var allCategories = context.Categorie;
            var categoriiRacheta = new HashSet<int>(racheta.CategoriiRacheta.Select(c => c.CategorieID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();

            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategorieID = cat.ID,
                    Denumire = cat.DenumireCategorie,
                    Assigned = categoriiRacheta.Contains(cat.ID)
                });
            }
        }

        public void UpdateBookCategories(Proiect_MDP_WebContext context, string[] selectedCategories, Racheta rachetaDeUpdatat)
        {
            if (selectedCategories == null)
            {
                rachetaDeUpdatat.CategoriiRacheta = new List<CategorieRacheta>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var bookCategories = new HashSet<int>
            (rachetaDeUpdatat.CategoriiRacheta.Select(c => c.Categorie.ID));
            foreach (var cat in context.Categorie)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!bookCategories.Contains(cat.ID))
                    {
                        rachetaDeUpdatat.CategoriiRacheta.Add(
                        new CategorieRacheta
                        {
                            RachetaID = rachetaDeUpdatat.ID,
                            CategorieID = cat.ID
                        });
                    }
                }
                else
                {
                    if (bookCategories.Contains(cat.ID))
                    {
                        CategorieRacheta courseToRemove
                        = rachetaDeUpdatat
                        .CategoriiRacheta
                        .SingleOrDefault(i => i.CategorieID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
