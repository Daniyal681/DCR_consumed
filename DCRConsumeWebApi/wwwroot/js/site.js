let spinBorder = `
    <div id="snipBorder" class="spinner-border spinner-border-sm text-light" role="status">
        <span class="sr-only">Loading...</span>
    </div>`;

$(document).ajaxComplete(function (event, request, settings) {
    if (request.responseJSON) {
        if (request.responseJSON.hasError) {
            toastr.error(request.responseJSON.error);
        }
    }
});

function loader(target, enabled) {
    if (enabled) {
        $(target).addClass('disabled');
        $(target).append(spinBorder);
    }
    else {
        setTimeout(function () {
            $(target).removeClass('disabled');
            $(snipBorder).remove();
        }, 1000);
    }
}