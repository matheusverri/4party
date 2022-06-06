$(document).ready(function () {
    if ($('#saida').length) {
        $('#datatable-saida').DataTable({
            'destroy': true,
            'paging': false,
            'info': false,
            'scrollCollapse': false,
            'filter': false,
            'ordering': false
        })
    }
})