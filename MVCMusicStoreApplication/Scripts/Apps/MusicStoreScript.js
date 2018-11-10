function searchFailed() {
    $("#searchresults").html("Search failed. Please try again");
}

$(function () {
    $(".RemoveLink").click(function () {
        alert("link clicked");
        var id = $(this).attr("data-id");
        $.post("/ShoppingCart/RemoveFromCart", { "id": id }, function (data) {
            //Populate elements in my view with data from the controller
            $("#update-message").text(data.Message);
            $("#cart-total").text(data.CartTotal);
            $("#item-count-" + data.DeleteId).text(data.ItemCount);
            if (data.ItemCount < 1)
                $("#record-" + data.DeleteId).fadeOut();//hide a row if count is 0
        });
    });
});