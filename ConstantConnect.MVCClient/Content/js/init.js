$(function () {
    $.support.transition = false;

    $('[data-toggle="popover"]').popover({
        html: true,
        content: function () {
            var content = $(this).attr("data-popover-content");
            return $(content).children(".popover-body").html();
        },
        title: function () {
            var title = $(this).attr("data-popover-content");
            return $(title).children(".popover-heading").html();
        }
    });

    $(document).mouseup(function (e) {
        var container = $(".popover1");
        if ((!container.is(e.target) && container.has(e.target).length === 0) && (container.has('a').length)) {
            container.popover("hide");
        }
    })

    $('#modal-container').on('hidden.bs.modal', function () {
        $(this).removeData('bs.modal');
        $('#modal-container .modal-content').empty();
    });

    $('#modal-container').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget);
        var url = button.attr("href");
        var modal = $(this);
        modal.find('.modal-content').load(url);
    });

    $('#table-listview').DataTable({
        responsive: true,
        info: false,
        scrollY: "500px",
        scrollX: true,
        scrollCollapse: true,
        paging: false,
        columnsDefs: [
            { "width": "30%", "targets": 0 }
        ],
        fixedColumns: true
    });

    $('#search-listview').keyup(function () {
        var value = this.value.toLowerCase().trim();
        $('#table-listview').find("tr").each(function (index) {
            if (!index) return;
            $(this).find("td").each(function () {
                var id = $(this).text().toLowerCase().trim();
                var notFound = (id.indexOf(value) == -1);
                $(this).closest('tr').toggle(!notFound);
                return notFound;
            })
        });
    });



    $('.data-table').DataTable({
        responsive: true,
        info: false,
        scrollY: "310px",
        scrollX: true,
        scrollCollapse: true,
        paging: false,
        columnsDefs: [
            { "width": "35%", "targets": 0 }
        ],
        fixedColumns: true
    });

    $('.modal-data-table').DataTable();

    $('#activerooms')
    .on('shown.bs.collapse',
        function () {
            $('.dataTable').DataTable().draw();
            $('#servicetickets').collapse('hide');
            $('#proactiverooms').collapse('hide');
            $('#roomperformance').collapse('hide');
        });

    $('#proactiverooms')
    .on('shown.bs.collapse',
        function () {
            $('.dataTable').DataTable().draw();
            $('#servicetickets').collapse('hide');
            $('#activerooms').collapse('hide');
            $('#roomperformance').collapse('hide');
        });

    $('#roomperformance')
    .on('shown.bs.collapse',
        function () {
            $('.dataTable').DataTable().draw();
            $('#servicetickets').collapse('hide');
            $('#activerooms').collapse('hide');
            $('#proactiverooms').collapse('hide');
        });

    $('#servicetickets')
    .on('shown.bs.collapse',
        function () {
            $('.dataTable').DataTable().draw();
            $('#roomperformance').collapse('hide');
            $('#activerooms').collapse('hide');
            $('#proactiverooms').collapse('hide');
        });


    //Inventory

    //var inventoryUrl = "/Inventory/InventoryTable";

    $(function () {
        $('#select-inventory').on('change', function () {
            var selected = $(this).find("option:selected").val();
            var inventoryUrl = "/Inventory/InventoryTable?Id=" + $(this).find("option:selected").val();
            //tableInventory.ajax.url(inventoryUrl).load(null, false);
            $.ajax({
                url: inventoryUrl,
                contentType: 'application/html; charset=utf8',
                type: 'GET',
                dataType: 'html'
            })
            .success(function (result) {
                $('#divInventoryTable').html(result);
            })
            .error(function (xhr, status) {
                console.log(status);
            })
        });
    });


});