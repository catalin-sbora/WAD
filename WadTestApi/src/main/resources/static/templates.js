/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

function getProductHtml(initialTemplate, product)
{
    var template = initialTemplate;
    var done = false;
    var currentTemplate = template;
    do
    {
        currentTemplate = template;
        template = template.replace("{productName}", product.name);
    }while (template !== currentTemplate);
    
    template = template.replace("{productDesc}", product.description);
    template = template.replace("{productPrice}", product.price);
    
    return template;
    
}

function getCategoryItemHtml(initialTemplate, category)
{
    var template = initialTemplate;
    
    template = template.replace("{categoryId}", "" + category.id);
    template = template.replace("{categoryName}", category.name);
    return '<li>' + template + '</li>';
}