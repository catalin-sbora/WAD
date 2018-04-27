/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

function getTemplate(templateName)
{
    return $.ajax({
            url: templateName
        });
}
function fillInProducts(container, products)
{   
   
   getTemplate("productTemplate.html").done(
            function (response)
            {
                var finalHtml="";
                for (var i = 0; i < products.length; i++) {
                        productHtml = getProductHtml(response, products[i]);
                        finalHtml = finalHtml + productHtml;
                    }
                    $(container).html(finalHtml);
            }
        );
}

function fillInCategoriesInMenu(menuContainer, categories)
{
    
    getTemplate("categoryListItemTmpl.html").done(
            function (template)
            {
                var finalHtml="";
                for (var i = 0; i < categories.length; i++) {
                        categoryHtml = getCategoryItemHtml(template, categories[i]);
                        finalHtml = finalHtml + categoryHtml;                        
                    }
                $(menuContainer).html(finalHtml);
            });
}

function showCategoryProducts(categoryId)
{
    $("#productsContainer").html("<b>Loading products...</b>");   
    var productsApi = new ProductsAPI();
    var products;
    productsApi.setBaseURL("");
    if (categoryId === "*")
    {
        products = productsApi.getAllProducts();
    }
    else
    {
        products = productsApi.getProductsInCategory(categoryId);
    }
    
    products.done(
        function (response) {
            fillInProducts($("#productsContainer"), response);           

        });
}

function showCategoriesInMenu(menuContainer)
{
    
    $(menuContainer).html("<b>Loading Categories...</b>");
    var productsApi = new ProductsAPI();
    var categories;
    productsApi.setBaseURL("");
    categories = productsApi.getAllCategories();
    
    categories.done(
            function (categoriesList)
            {
                fillInCategoriesInMenu($(menuContainer), categoriesList);
            });
    
}