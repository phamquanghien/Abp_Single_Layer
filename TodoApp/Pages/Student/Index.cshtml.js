$(function () {
    
    // DELETING ITEMS /////////////////////////////////////////
    $('#studentList').on('click', 'tr td i', function(){
        var $td = $(this).parent();
        var $tr = $td.parent();
        var id = $td.attr('data-id');
        todoApp.services.student.delete(id).then(function(){
            $tr.remove();
            abp.notify.info('Deleted the Student item.');
        });
    });
    
    // CREATING NEW ITEMS /////////////////////////////////////
    $('#NewItemForm').submit(function(e){
        e.preventDefault();
        var fname = $('#FullName').val();
        var address = $('#Address').val();        
        todoApp.services.student.create(fname, address).then(function(result){
            $("#studentList").append(
                '<tr><td>' + fname + '</td><td>'
                + result.address + '</td><td data-id="'+ result.id
                + '"><i class="fa fa-trash-o"></i></td></tr>'
            );
        });
    });
});
