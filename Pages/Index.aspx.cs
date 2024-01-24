using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{

    //classes that will be used for the recipes
    public class Recipe
    {
        public List<RecipeDetail> details;
        //one per lang

        public int preptimeinmins;
        public int cookingtimeinmins;
        public int serves;
    }
    public class RecipeDetail
    {
        public string title;
        public string ingredents;
        public string instructions;
    }

    List<Recipe> recipes = new List<Recipe>();

    private void initRecipes() // storing all the recipes
    {
        List<RecipeDetail> dts = new List<RecipeDetail>();
        dts.Add(new RecipeDetail() { title = "Beef stroganoff", ingredents = "½ tbsp light olive oil\r\n1 large onion, finely sliced\r\n3 garlic cloves, finely chopped\r\n1 beef stock cube...", instructions = "Heat the light olive oil in a large..." }); //ref https://www.bbc.co.uk/food/recipes/beef_stroganoff_16029
        dts.Add(new RecipeDetail() { title = "biff Stroganoff", ingredents = "½ msk lätt olivolja\r\n1 stor lök, fint skivad\r\n3 vitlöksklyftor, finhackad\r\n1 buljongtärning...", instructions = "Hetta upp den lätta olivoljan i en stor..." });

        // rec 1
        recipes.Add(new Recipe()
        {
            details = dts,
            serves = 4,
            preptimeinmins = 10,
        });


        dts = new List<RecipeDetail>();
        dts.Add(new RecipeDetail() { title = "Bangers and mash", ingredents = "1 tbsp sunflower oil\r\n8 pork sausages (the best quality you can find)\r\nsmall knob of butter\r\n3 small onions, finely sliced\r\n1 thyme sprig...", instructions = "Heat the oven to 200C/180C fan/gas 6. Heat the oil in an ovenproof frying pan..." }); //ref https://www.bbcgoodfood.com/recipes/bangers-n-mash-with-onion-gravy
        dts.Add(new RecipeDetail() { title = "Korv och mos", ingredents = "1 msk solrosolja\r\n8 fläskkorvar (den bästa kvaliteten du kan hitta)\r\nliten klick smör\r\n3 små lökar, fint skivade\r\n1 timjankvist...", instructions = "Värm ugnen till 200C/180C fläkt/gas 6. Värm oljan i en ugnssäker stekpanna..." });
        // rec 2
        recipes.Add(new Recipe()
        {
            details = dts,
            serves = 6,
            preptimeinmins = 20,
            cookingtimeinmins = 25
        });
    }

    protected void Page_Load(object sender, EventArgs e) //on page loads run
    {
        initRecipes(); //load the recipes

        if (!IsPostBack) // check if this is a postback (is the first time on the page)
        {
            // populate the dropdown
            ddlrecipes.Items.Add(new ListItem("select recipe...")); //add to the to the recipe drop down
            foreach (Recipe rec in recipes)
            {
                ddlrecipes.Items.Add(new ListItem(rec.details[0].title));
            }
        }
    }

    protected void ddlang_SelectedIndexChanged(object sender, EventArgs e) //What happens when chaning lang
    {
        int langix = ddlang.SelectedIndex;
        ddlrecipes.Items.Clear(); //clear recipe dropdown
        ddlrecipes.Items.Add(new ListItem("select recipe...")); //add to the recipe dropdown
        foreach (var rec in recipes)
        {
            ddlrecipes.Items.Add(new ListItem(rec.details[langix].title));
        }
        //when changing language reset recipe text
        lttitle.Text = ""; 
        ltserves.Text = "";
        ltinstructions.Text = "";
        ltindegdents.Text = "";
    }

    protected void ddlrecipes_SelectedIndexChanged(object sender, EventArgs e) //run when selecting a recipe
    {
        int id = ddlrecipes.SelectedIndex; //changes id depending on what was selected
        int langid = ddlang.SelectedIndex;
        if (id > 0)
        {
            Recipe rec = recipes[id - 1]; //-1 as the first thing in the drop down list is now "select recipe..."

            lttitle.Text = rec.details[langid].title;//setting texts on page
            ltserves.Text = rec.serves.ToString();
            ltinstructions.Text = rec.details[langid].instructions;
            ltindegdents.Text = rec.details[langid].ingredents;
        }
        else
        {
            lttitle.Text = ""; //clear text 
            ltserves.Text = "";
            ltinstructions.Text = "";
            ltindegdents.Text = "";
        }
    }
}