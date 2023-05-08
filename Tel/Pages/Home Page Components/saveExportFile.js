function saveAsFile(filename, bytesBase64, contentType) {
    var link = document.createElement('a');
    document.body.appendChild(link);

    link.href = "data:" + contentType + ";base64," + bytesBase64;
    link.download = filename;
    link.target = "_blank";

    link.click();

    document.body.removeChild(link);
}