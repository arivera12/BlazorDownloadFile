window.downloadFile = function (filename, bytesBase64) {
    var link = document.createElement('a');
    link.download = filename;
    link.style.display = "none";
    link.href = "data:application/octet-stream;base64," + bytesBase64;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
};
