<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="MercanciaCeroFaltantesResumen.aspx.vb" Inherits="com.isocraft.backbone.ccentral.MercanciaCeroFaltantesResumen" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>


<html>
<head>
    <title>Sistema Administrador de Sucursal</title>

    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
    <link rel="stylesheet" href="../static/css/menu.css">
    <link rel="stylesheet" href="../static/css/menu2.css">
    <link rel="stylesheet" href="../static/css/estilo.css">
    <script language="JavaScript" src="../static/scripts/Tools.js"></script>
    <script language="JavaScript" src="../static/scripts/menu.js"></script>
    <script language="JavaScript" src="../static/scripts/menu_items.js"></script>
    <script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
    <script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
    <script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
    <script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
    <script language="JavaScript" id="clientEventHandlersJS">
<!--

    function window_onload() {
        MM_preloadImages('../static/images/bsalir_on.gif', '../static/images/bayuda_on.gif');
        document.forms[0].action = "<%=strFormAction%>";
}

function strGetCustomDateTime() {
    document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
    return (true);
}

function frmMercanciaCeroFaltantesResumen_onsubmit() {
    valida = true;
    return (valida);
}

function cmdRegresar_onclick() {
    window.location = "MercanciaCeroFaltantes.aspx";
}

function trim(stringToTrim) {
    return stringToTrim.replace(/^\s+|\s+$/g, "");
}

//Metodo que genera la tabla HTML con informacion a imprimir.
function cmdImprimir_onclick(id) {

    
    var tablaResumen = trim(document.getElementById('tblCeroFaltantes').innerHTML);
    var tablaCeros = trim(document.getElementById('divConsultaCeroFaltantesCero').innerHTML);
    var tablaFactor = trim(document.getElementById('divConsultaCeroFaltantesFactor').innerHTML);

    //Validacion de resultados
    if (id == 0 && (tablaResumen == '' || tablaResumen == 'No hay resultados de la consulta')) {
        alert('No hay resultados de la consulta Cero Faltantes Resumen');
        return (false);
    }
    else if (id == 1 && (tablaCeros == '' || tablaCeros == 'No hay resultados de la consulta')) {
        alert('No hay resultados de la consulta Cero Faltantes Ceros');
        return (false);
    }
    else if (id == 2 && (tablaFactor == '' || tablaFactor == 'No hay resultados de la consulta')) {
        alert('No hay resultados de la consulta Cero Faltantes Factor');
        return (false);
    }
    else {
        //Si la validacion es correcta se ejecuta rutina para imprimir en servidor.
        document.forms[0].action = "<%=strFormAction%>?strCmd=Imprimir&strImprimirTablaId=" + id;
        document.forms[0].target = "ifrOculto";
        document.forms[0].submit();
        document.forms[0].target = '';

        return (true);
    }
}

function fnImprimir(strCeroFaltantes) {

    //Llamada desde el servidor para imprimir resultados de las consulta.
    document.ifrPageToPrint.document.all.divContenido.innerHTML = strCeroFaltantes;
    document.ifrPageToPrint.focus();
    window.print();

}


//-->
</script>
    <style>
        #divErrortblCeroFaltantes, #divConsultaCeroFaltantesCero, #divConsultaCeroFaltantesFactor {
        color:red;
        }
    </style>

</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaCeroFaltantesResumen" onSubmit="return frmMercanciaCeroFaltantesResumen_onsubmit()">
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr> 
      <td valign="top" height="98" width="100%"><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
    <tr> 
      <td valign="top" height="34" width="100%"><img src="../static/images/pixel.gif" width="1" height="34"></td>
    </tr>
    <tr> 
      <td width="100%"> <table width="100%" border="0" cellpadding="0" cellspacing="0">
          <tr> 
            <td width="10" bgcolor="#ffffff"><img src="../static/images/pixel.gif" width="10" height="8"></td>
            <td width="583" class="tdmigaja">
                <span class="txdmigaja">Está en : 
                </span>
                <a href="Mercancia.aspx" class="txdmigaja">Mercancía</a>
                <span class="txdmigaja"> 
                : Cero Faltantes
                </span>
            </td>
            <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont">
                <script language="JavaScript">crearDatosSucursal()</script><br />
              <br>
                <%' Tabla 1 '%> 
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <div id="tblCeroFaltantes" style="width:100%"></div>
                            <div id="divErrortblCeroFaltantes" style="width:100%"></div>
                        </td>
                    </tr>
                    <tr>
                        <td  align="right">
                            <input name="cmdImprimir" type="button" class="boton" value="Imprimir" onClick="return cmdImprimir_onclick(0)"> 
                        </td>
                    </tr>
                </table>
              <br><br>
                <%' Tabla 2 '%> 
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <div id="tblCeroFaltantesCero" style="width:100%"></div>
                            <div id="divErrortblCeroFaltantesCero" style="width:100%"></div> 
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <input name="cmdImprimirCero" type="button" class="boton" value="Imprimir" onClick="return cmdImprimir_onclick(1)"> 
                        </td>
                    </tr>
                </table>
                
                
                <br><br>
                <%' Tabla 3 '%>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <div id="tblCeroFaltantesFactor" style="width:100%"></div>
                            <div id="divErrortblCeroFaltantesFactor" style="width:100%"></div> 
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <input name="cmdRegresarFactor" type="button" class="boton" value="Imprimir" onClick="return cmdImprimir_onclick(2)">
                            
                        </td>
                    </tr>
                    <tr>
                        <td><input name="cmdRegresarFactor" type="button" class="boton" value="Regresar" onClick="return cmdRegresar_onclick()" style="right: auto"> </td>
                    </tr>
                </table> 
              <br>  
            </td>
            <td width="187" rowspan="2" valign="top" class="tdcolumnader"> 
            </td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script> 
            </td>
          </tr>
        </table></td>
    </tr>
  </table>
  <script language="JavaScript">
	<!--
    new menu(MENU_ITEMS, MENU_POS);
    new menu(MENU_ITEMS2, MENU_POS2);
    //-->
  </script>
</form>
    <div style="display:none;">
        <div id="divConsultaCeroFaltantes">
            <%= Me.strTablaConsultaCeroFaltantes()%>
        </div>
        <div id="divConsultaCeroFaltantesCero">
            <%= Me.strTablaConsultaCeroFaltantesCero()%>
        </div>            
        <div id="divConsultaCeroFaltantesFactor">
            <%= Me.strTablaConsultaCeroFaltantesFactor()%>
        </div>            
    </div>
        <script language="JavaScript">

        var tablaTotal = document.getElementById('tblCeroFaltantes').innerHTML
        if (trim(tablaTotal) == '') {
            document.getElementById('divErrortblCeroFaltantes').innerHTML = 'No hay resultados de la consulta';
        }
        
        </script>
        
    <iframe name="ifrOculto" src="" width="0" height="0"></iframe>
    <iframe name="ifrPageToPrint" src="ifrPaginaenBlanco.aspx" width="0" height="0" marginheight="0" marginwidth="0"></iframe>
</body>
</html>
