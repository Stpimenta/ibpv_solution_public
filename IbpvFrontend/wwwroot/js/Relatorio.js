
function startDownload(base64Data, fileName) {
    // Criar um link de download
    const link = document.createElement('a');
    link.href = 'data:application/octet-stream;base64,' + base64Data;
    link.download = fileName;

    // Iniciar o download
    link.click();
}