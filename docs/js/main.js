function generateV1Password(pass, name) {
    var hash = CryptoJS.SHA3(pass + name).toString();
    return "!" + hash.slice(0, 18) + "A";
}

function generateV2Password(pass, name) {
    var hash = CryptoJS.SHA3(pass + name.toLowerCase()).toString();
    return "$!" + hash.slice(0, 18) + "A";
}
