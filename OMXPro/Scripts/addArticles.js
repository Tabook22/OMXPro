$(document).ready(function () {
        console.log("أستغفر الله و اتوب إليه");
        $(function () {
            var gimg = $("#a_img").val();
            $("#myimg").attr("src", gimg);
            $("#a_img").on("change", function () {
                var getimg = $(this).val();
                $("#myimg").attr("src", getimg);
            });

            $('#myModal').on('shown.bs.modal', function () {
                $('#myInput').focus()
            })
        });

        //thead th a ---> webgrid header link (sorting) , tfoot a     --> webgrid footer link (paging)
        $("#demoArea").on("click", "thead th a, tfoot a", function (e) {
            e.preventDefault();
            var param = $(this).attr('href').split('?')[1];
            var url = '@Url.Action("GetPostData", "PostList")' + '?' + param;
            $.ajax({
                url: url,
                type: 'GET',
                data: '',
                dataType: 'html',
                success: function (data) {
                    $('#demoArea').html(data);
                },
                error: function () {
                    alert('Error!');
                }
            });
        });

        //get the article title and hyperlink from the popup menu
        $(document).on("click", ".getInfo", function (e) {
            e.preventDefault();
            var row = $(this).closest('tr'); // get the table row
            var pId = row.find('.getId'); // get the post id
            var artId = pId.eq(0).text();

            var pImg = row.find('.pstImg'); // get the post img
            var pstImg = pImg.eq(0).attr("src");

            var pSm = row.find('.getSm'); // get the post img
            var pSmm = pSm.eq(0).text();

            var t1 = $(this).text();
            var action = $(this).data("action");
            var controller = $(this).data("controller");

            //artId = controller + "/" + action + "/" + artId;
            $('#a_title').val(t1);
            //$('#a_link').val("http://www.geventoman.com/" + controller + "/" + action + "/" + artId);
            $('#a_link').val("http://geventoman.com/" + controller + "/" + action + "/" + artId);
            $('#a_img').val(pstImg);
            $("#myimg").attr("src", pstImg);
            $("#a_desc").val(pSmm);

        });

        // change section background color in the dropdwonlist
        $(function () {
            $('#SectionsName option[value="3"]').css({ "border-bottom": "1px solid #222", "padding-bottom": "10px" });
            $('#SectionsName option[value="6"]').css({ "border-bottom": "1px solid #222", "padding-bottom": "10px" });
            $('#SectionsName option[value="9"]').css({ "border-bottom": "1px solid #222", "padding-bottom": "10px" });
            $('#SectionsName option[value="1"]').css("background-color", "#F0F0F0");
            $('#SectionsName option[value="2"]').css("background-color", "#F0F0F0");
            $('#SectionsName option[value="3"]').css("background-color", "#F0F0F0");
            $('#SectionsName option[value="4"]').css("background-color", "#ccc");
            $('#SectionsName option[value="5"]').css("background-color", "#ccc");
            $('#SectionsName option[value="6"]').css("background-color", "#ccc");
            $('#SectionsName option[value="7"]').css("background-color", "#F0F0F0");
            $('#SectionsName option[value="8"]').css("background-color", "#F0F0F0");
            $('#SectionsName option[value="9"]').css("background-color", "#F0F0F0");
            $('#SectionsName option[value="10"]').css("background-color", "#ccc");
            $('#SectionsName option[value="11"]').css("background-color", "#ccc");
            $('#SectionsName option[value="12"]').css("background-color", "#ccc");
            $('#SectionsName option[value="13"]').css("background-color", "#ccc");
        });
    });