$(document).ready(function () {
    //====================================================== select multiple rows for delete =============================================================
    function DelSocials() {
        if (confirm("Are you sure to delete records")) {
            $('#socialdata table tr').each(function () {
                if ($(this).find("input[id*='chkSo']").length > 0) {
                    if ($(this).find("input[id*='chkSo']")[0].checked == true) {
                        var userID = $(this).find("input[id*='chkSo']").val();
                        var data = { ID: userID };
                        var temp = $(this);
                        $.getJSON("/Admin/SiteSettings/DelSocials", data, function (response) {
                            if (response == true) {
                                temp.remove();
                            }
                        });
                    }
                }
            });
        }
    }
    //====================================================== Method to save data into database ===========================================================
    function saveData() {
        //==== Call validateData() Method to perform validation. This method will return 0
        //==== if validation pass else returns number of validations fails.
        var errCount = validateData();
        //==== If validation pass save the data.
        if (errCount > 0) {

            $("form").submit(function (e) {
                e.preventDefault();
            });
        }
        var txtName = $("#txtName").val();
        var txtLink = $("#txtLink").val();
        var txtOrder = $("#txtOrder").val()
        var txtImg = $("#txtImg").val();
        //
        var id = $("#hfSelectedRecord").val();
        //
        $.ajax({
            type: "POST",
            url: '@Url.Action("addSlMedia", "SiteSettings")',// location.pathname + "topNav/saveData",
            data: "{Name:'" + txtName + "',Link:'" + txtLink + "',Order:'" + txtOrder + "',Img:'" + txtImg + "',id:'" + id + "'}",
            contentType: "application/json; charset=utf-8",
            datatype: "jsondata",
            async: "true",
            success: function (data) {
                $("#socialdata").html(data);

            },
            error: function (response) {
                alert(response.status + ' ' + response.statusText);
            }
        });
        //=== Hide save button and show update button.
        $("#btnSave").css("display", "block");
        $("#btnUpdate").hide();
        //$("#btnDelete").css("display", "block");
        CleanTxt();
    }
    //====================================================== Method to validate textboxes ================================================================
    function validateData() {
        var txtName = $("#txtName").val();
        var txtLink = $("#txtLink").val();
        var txtOrder = $("#txtOrder").val()
        var txtImg = $("#txtImg").val();

        var errMsg = "";
        var errCount = 0;
        if (txtName.length <= 0) {
            errCount++;
            errMsg += "<li>Please enter Social Site Title.</li>";
        }

        if (txtLink.length <= 0) {
            errCount++;
            errMsg += "<li>Please enter Link.</li>";
        }
        if (txtOrder.length <= 0) {
            errCount++;
            errMsg += "<li>Please enter Order.</li>";
        }

        if (txtImg.length <= 0) {
            errCount++;
            errMsg += "<li>Please enter social site image link.</li>";
        }
        if (errCount > 0) {

            $(".errMsg ul").remove()
            $(".errMsg").append("<ul>" + errMsg + "</ul>");
            $(".errMsg").slideDown('slow');
        }
        return errCount;
    }
    //====================================================== Method to bind values of selected record into input controls for update operation ===========
    $(function () {
        $(".sedit").on("click", function (e) {
            e.preventDefault();
            //clean the text field befor using them

            var id = $(this).attr('data-itemid');

            var url = '@Url.Action("showEditData")' + '?id=' + id;
            $.ajax({
                type: "POST",
                url: url,
                data: "{}",
                contentType: "application/json; charset=utf-8",
                datatype: "jsondata",
                async: "true",
                success: function (response) {
                    //var msg = eval('(' + response.d + ')');
                    var msg = response;
                    var opval = msg.ParentId;

                    //fill in the text fields
                    $("#txtName").val(msg.Name);
                    $("#txtLink").val(msg.Link);
                    $("#txtOrder").val(msg.Order);
                    $("#txtImg").val(msg.img);

                    //=== store id of the selected record in hidden field so that we can use it later during
                    //=== update process.
                    $("#hfSelectedRecord").val(id);

                    //=== Hide save button and show update button.
                    $("#btnSave").hide();
                    $("#btnUpdate").css("display", "block");
                    //$("#btnDelete").css("display", "block");

                },
                error: function (response) {
                    alert(response.status + ' ' + response.statusText);
                }
            });
        });
    });
    //====================================================== Clean Text ==================================================================================
    function CleanTxt() {
        $("#txtName").val("");
        $("#txtLink").val("");
        $("#txtOrder").val("");
        $("#txtImg").val("");

    }
    //====================================================== Method to update record =====================================================================
    function updateData() {
        console.log("اللهم صلي على محمد و على آلي محمد");
        var errCount = validateData();
        //==== If validation pass save the data.
        if (errCount == 0) {
            var txtName = $("#txtName").val();
            var txtLink = $("#txtLink").val();
            var txtOrder = $("#txtOrder").val()
            var txtImg = $("#txtImg").val();
            //
            var id = $("#hfSelectedRecord").val();
            //
            $.ajax({
                type: "POST",
                url: '@Url.Action("editSocials", "SiteSettings")',// location.pathname + "topNav/saveData",
                data: "{Name:'" + txtName + "',Link:'" + txtLink + "',Order:'" + txtOrder + "',Img:'" + txtImg + "',id:'" + id + "'}",
                contentType: "application/json; charset=utf-8",
                datatype: "jsondata",
                async: "true",
                success: function (data) {
                    $("#socialdata").html(data);

                },
                error: function (response) {
                    alert(response.status + ' ' + response.statusText);
                }
            });
            //=== Hide save button and show update button.
            $("#btnSave").css("display", "block");
            $("#btnUpdate").hide();
            //$("#btnDelete").css("display", "block");

            CleanTxt();
        }
    }
});