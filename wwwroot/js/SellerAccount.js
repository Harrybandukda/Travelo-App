document.addEventListener('DOMContentLoaded', function () {
    const termsCheckbox = document.getElementById('termsCheckbox');
    const termsModal = document.getElementById('termsModal');
    const agreeBtn = document.getElementById('agreeBtn');
    const disagreeBtn = document.querySelector('.modal-footer .btn-secondary'); // Select the Disagree button

    termsCheckbox.addEventListener('change', function () {
        if (termsCheckbox.checked) {
            $(termsModal).modal('show');
        }
    });

    $(termsModal).on('hide.bs.modal', function (e) {
        if (!termsCheckbox.checked) {
            termsCheckbox.checked = false;
        }
    });

    agreeBtn.addEventListener('click', function () {
        termsCheckbox.checked = true;
        $(termsModal).modal('hide');
    });

    disagreeBtn.addEventListener('click', function () {
        termsCheckbox.checked = false; // Uncheck the checkbox when disagree is clicked
        $(termsModal).modal('hide');
    });

    $(termsModal).on('hidden.bs.modal', function () {
        if (!termsCheckbox.checked) {
            termsCheckbox.checked = false;
        }
    });


});