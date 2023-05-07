﻿function DescargarExcel(nombre, base64) {

    const link = document.createElement("a");
    link.download = nombre;
    link.href = "data:application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;base64," + base64;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}