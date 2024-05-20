function validatePassword() {
    var password = document.getElementById('password').value;
    var criteria = {
        length: password.length >= 8,
        uppercase: /[A-Z]/.test(password),
        number: /[0-9]/.test(password),
        special: /[^A-Za-z0-9]/.test(password)
    };

    document.getElementById('passwordCriteria').style.display = 'block';

    setCriteriaClass('length', criteria.length);
    setCriteriaClass('uppercase', criteria.uppercase);
    setCriteriaClass('number', criteria.number);
    setCriteriaClass('special', criteria.special);
}

function setCriteriaClass(criteriaId, isValid) {
    var element = document.getElementById(criteriaId);
    if (isValid) {
        element.className = 'valid';
    } else {
        element.className = 'invalid';
    }
}