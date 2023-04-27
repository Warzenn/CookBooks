// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


var ingredientRowCount = 0;


    ingredientRowCount = 0;
    ingredientRowCount = parseInt(localStorage.getItem("ingredientCountStorage"));

}
else {
    ingredientRowCount = 2;
    localStorage.setItem(ingredientCountStorage, ingredientRowCount);





function addIngredientRow() {

    if (localStorage.hasOwnProperty("ingredientCountStorage")) {

        ingredientRowCount = parseInt(localStorage.getItem("ingredientCountStorage"));

    }
    else {
        ingredientRowCount = 2;
        localStorage.setItem(ingredientCountStorage, ingredientRowCount);

    }

    let ingredientsCount = ingredientRowCount + 1;
    ingredientRowCount++;

    let container = document.getElementById("tbbodyIngredients")
    
    let newRow = document.createElement("tr");
    let newData = document.createElement("td");
    let ingredientInput = document.createElement("input");
   
    newRow.id = "ingredient" + String(ingredientsCount);
    container.appendChild(newRow);
        
    newRow.appendChild(newData);
        
    ingredientInput.setAttribute("asp-for", "Ingredients[" + ingredientRowCount + "].Ingredient");
    ingredientInput.setAttribute("class", "form-control");
    ingredientInput.setAttribute("placeholder", "Enter " + ingredientsCount + ". ingredients");
    ingredientInput.setAttribute("name", "Ingredients[" + ingredientRowCount + "].Ingredient");
    ingredientInput.setAttribute("value", "");
    newData.appendChild(ingredientInput);
    
    localStorage.ingredientCountStorage = ingredientRowCount;

}

function deleteIngredientRow() {

    let ingredientId = "ingredient" + String(ingredientRowCount);
    let ingredientList = document.getElementById(ingredientId);
    if (ingredientRowCount == 1) {
        window.alert("Need at least 1 ingredient")
    }
    else {
        ingredientList.remove();
        ingredientRowCount--;
        localStorage.ingredientCountStorage = ingredientRowCount;
    }
 
    

}




//$(function () {
//    $("#btnAddNewIngredients").click(function () {
//        var count = $("#tbbodyIngredients >tr").length;
//        var i = $("#tbbodyIngredients >tr").length + 1;
//        $("#tbbodyIngredients").append("<tr><td> <input asp-for='Ingredients[" + count + "].Ingredient' name ='Ingredients[" + count + "].Ingredient' type='text-test' class='form-control' placeholder='Enter " + i + ". ingredients' ");
//        $("#tbbodyIngredients").append("<span asp-validation-for='Ingredients[" + count + "].Ingredient' class'text-danger'></span> ");
//    });
//});

//$(function () {
//    $("#btnAddNewInstructions").click(function () {
//        var count = $("#tbbodyInstructions >tr").length;
//        var i = $("#tbbodyInstructions >tr").length + 1;
//        $("#tbbodyInstructions").append("<tr><td> <input asp-for='Instructions[" + count + "].Instruction' name ='Instructions[" + count + "].Instruction' type='text-test' class='form-control' placeholder='Enter " + i + ". instructions' ");
//        $("#tbbodyInstructions").append("<span asp-validation-for='Instructions[" + count + "].Instruction' class'text-danger'></span> ");
//    });
//});

//$(function () {
//    $("#btnDeleteInstructions").click(function () {

//        $(this).("#tbbodyInstructions").removeChild();
        
//    });
//});



//$("#tbbody").append("<tr><td> <input class='form-control' name='Model.Instructions[" + count + "]'</td></tr>");

