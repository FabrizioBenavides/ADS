<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" enableViewState="False" Explicit="True" Trace="False" Strict="True" CodeBehind="SucursalProveedoresEditarArticulosAutorizados.aspx.vb"      Inherits="com.isocraft.backbone.ccentral.SucursalProveedoresEditarArticulosAutorizados" codePage="28592" %>
<HTML>
<HEAD>
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<link href="css/menu.css" type="text/css" rel="stylesheet">
<link href="css/estilo.css" type="text/css" rel="stylesheet">
<script language="JavaScript" src="js/menu.js" type="text/JavaScript"></script>
<script language="JavaScript" src="js/menu_items.js" type="text/JavaScript"></script>
<script language="JavaScript" src="js/menu_tpl.js" type="text/JavaScript"></script>
<script language="JavaScript" src="js/headerfooter.js" type="text/JavaScript"></script>
<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" type="text/JavaScript" src="../static/scripts/FuncionesString.js"></script>
<script id="clientEventHandlersJS" language="javascript">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  document.forms[0].action = "<%= strFormAction %>";  
  
  intOpcAct = "<%=intOpcAct%>";
  
  if (intOpcAct == "1") {       
       document.forms[0].elements['optAct1'].checked = true;    
  }
  if (intOpcAct == "2") {
       document.forms[0].elements['optAct2'].checked = true;    
  }  
  

  
  <%= strJavascriptWindowOnLoadCommands %>
    
}

// Mandar ventana de consulta
function Pop(url, width, height) {
    var Win = window.open(url,'Pop','width=' + width + ',height=' + height + ',left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no' );
	return(false);
}

function txtArticulosArchivo_onfocus() {
	document.frmMain.optAct["0"].checked = true;
}

function txtProveedorNombreId_onfocus() {
   document.frmMain.optAct["1"].checked = true;
}

function txtProveedorNombreId_onKeyDown() {
	if(event.keyCode==13){ txtProveedorNombreId_onblur() }
	if(event.keyCode==9) { txtProveedorNombreId_onblur() }
}

function txtProveedorNombreId_onblur() {

   strProveedorCapturado = Trim(document.forms[0].elements['txtProveedorNombreId'].value); 

   if (strProveedorCapturado.length > 0 && strProveedorCapturado!='0') {
      
      if (document.forms[0].elements['hdnProveedorNombreId'].value != document.forms[0].elements['txtProveedorNombreId'].value) {	       
           objLupaProveedor_onclick(); 
      }
   }
   else {
      return true;
   }
   
}

// Lupa para listar proveedores
function objLupaProveedor_onclick() {
   
   var valida = true;   
   var intCuentaApostrofes=0;  
   var strtxtProveedorNombreId = "";
   
   strtxtProveedorNombreId = Trim(document.forms[0].elements['txtProveedorNombreId'].value);
         
   if (strtxtProveedorNombreId.length< 1) {
       alert("Teclear Número de proveedor o descripción");
       document.forms[0].elements['txtProveedorNombreId'].focus();
       return(false);
   }
        
   intCuentaApostrofes = strtxtProveedorNombreId.search("'");
      
   if (intCuentaApostrofes != -1) {
       document.forms[0].elements['txtProveedorNombreId'].value = '';
       alert("No se deben de capturar apostrofes");
       document.forms[0].elements['txtProveedorNombreId'].focus();
       return(false);
   }
   
   if (document.forms[0].elements['hdnProveedorNombreId'].value == document.forms[0].elements['txtProveedorNombreId'].value) {	       
      return(true);   
   }
   
   var strtxtProveedorB = Trim((document.forms[0].elements['txtProveedorNombreId'].value).substring(0,4));

   if (isNaN(strtxtProveedorB) || strtxtProveedorB.length<1 ) // Esta capturando Descripcion
   {   
             	         
      strEvalJs='opener.txtProveedorNombreId_onblur();';
      strParametros = ''		
      strParametros = strParametros + ' campoProveedorId=hdnProveedorId';
      strParametros = strParametros + '&campoProveedorNombreId=txtProveedorNombreId';
      strParametros = strParametros + '&campoProveedorRazonSocial=txtProveedorRazonSocial';
      strParametros = strParametros + '&strProveedorId=' + document.forms[0].elements['txtProveedorNombreId'].value;
      	  			       
      Pop('PopProveedor.aspx?'+strParametros+'&strEvalJs='+strEvalJs,500,540); 
   }   
   else {
   
       if (document.forms[0].elements['optAct1'].checked==true) {
           intOpcAct = "1";    
       }
       if (document.forms[0].elements['optAct2'].checked==true) {
           intOpcAct = "2";    
       }
       
       document.forms[0].action = "<%=strFormAction%>?strCmd=BuscarProveedor&intproveedorDestinoId=" + "<%=intproveedorDestinoId%>" +  "&strProveedorDestinoNombreId=" + "<%=strProveedorDestinoNombreId%>" + "&strProveedorDestinoRazonSocial=" + "<%=strProveedorDestinoRazonSocial%>" + "&intOpcAct=" + intOpcAct;
       document.forms[0].target="ifrOculto";
       document.forms[0].submit();
       document.forms[0].target='';  
  }  
  
}	
  
function fnUpBuscarProveedor (intProveedorId,strProveedorNombreId,strProveedorRazonSocial,strProveedorRFC, intError) {  

    if(intError == 0){
        document.forms(0).hdnProveedorId.value = intProveedorId;
     	document.forms(0).hdnProveedorNombreId.value = strProveedorNombreId;
		document.forms(0).txtProveedorNombreId.value = strProveedorNombreId;
	    document.forms(0).txtProveedorRazonSocial.value = strProveedorRazonSocial;
	}
	else{
		alert("Proveedor no encontrado.");

		document.forms(0).hdnProveedorId.value = '';		
		
		document.forms(0).hdnProveedorNombreId.value = '';
		document.forms(0).txtProveedorNombreId.value = '';
		document.forms(0).txtProveedorRazonSocial.value='';
		
		document.forms(0).txtProveedorNombreId.focus();
		document.forms(0).txtProveedorNombreId.select();
	}
}	 

function objPrevioCarga_onclick() {
   
   if (blnEntradaValida()) {
       
       var intOpcAct = "";
       if (document.forms[0].elements['optAct1'].checked==true) {
           intOpcAct = "1";    
       }
       if (document.forms[0].elements['optAct2'].checked==true) {
           intOpcAct = "2";    
       }
       
       document.forms[0].action = "<%=strFormAction%>?strCmd=PrevioArchivoArticulo"+ "&intproveedorDestinoId=" + "<%=intproveedorDestinoId%>" +  "&strProveedorDestinoNombreId=" + "<%=strProveedorDestinoNombreId%>" + "&strProveedorDestinoRazonSocial=" + "<%=strProveedorDestinoRazonSocial%>" + "&intOpcAct=" + intOpcAct;
       document.forms[0].target="ifrOculto";
       document.forms[0].submit();
       document.forms[0].target=''; 
   }
   	   
}

function fnVerPrevioArchivo (intCargaArchivo, lngFolioActualCarga) {    
 
   if (intCargaArchivo >= 0) {
       document.forms(0).hdnFolioActualCarga.value = lngFolioActualCarga;
       url = 'popSucursalProveedoresConsultar.aspx?strCmd=VistaPrevia&lngFolioActualCarga=' + lngFolioActualCarga;      
       var Win = window.open(url,'Pop','width=620,height=540,left=20,top=10,resizable=no,scrollbars=yes,menubar=no,status=no' );
   }
   else {
      if (intCargaArchivo==-100) {
	      alert("No se pudo abrir o no existe el archivo de carga");
	  }
	  if (intCargaArchivo==-110) {
	      alert("Los registros del archivo no cumplen con la estructura (solo el número de articulo).");
	  }
   }
   
}

function objLupaArticulo_onclick() {
   document.frmMain.optAct["1"].checked = true;
   
   if (blnEntradaValida()) {
      url = 'popSucursalProveedoresConsultar.aspx?strCmd=VerA&intproveedorId=' + document.forms(0).hdnProveedorId.value + '&strProveedorNombreId=' + document.forms(0).hdnProveedorNombreId.value + '&strProveedorRazonSocial=' + document.forms(0).txtProveedorRazonSocial.value  ;
	  var Win = window.open(url,'Pop','width=770,height=640,left=20,top=10,resizable=no,scrollbars=yes,menubar=no,status=no' );
   }
}

function blnEntradaValida() {  
   if (document.forms[0].elements['optAct1'].checked==false && document.forms[0].elements['optAct2'].checked==false) {
       alert("Debe indicar el origen de la carga (Desde archivo o proveedor)");
        return(false);
   }
   
   if (document.forms[0].elements['optAct1'].checked==true) { // Carga desde Archivo
       if (document.forms[0].elements["txtArticulosArchivo"].value.length == 0) {
           alert("Por favor especifique un valor para el campo \"Archivo\".");
           document.forms[0].elements["txtArticulosArchivo"].focus();
           return(false);
       }     
   }
   
   if (document.forms[0].elements['optAct2'].checked==true) {// Carga desde otro proveedor
       if (document.forms(0).hdnProveedorId.value <1) {
           alert("Debe haberse capturado un proveedor valido");
           return(false);
       }    
   }      
   
   return (true);      
}


function cmdRemplazar_onclick() {
   
   if (blnEntradaValida()) {
       
       // Confirmar el Remplazo
       var intResultado = window.confirm("\277Los articulos existentes se eliminaran quedando solo los de la carga ?");
          
       if(intResultado){   
       
           var intOpcAct = "";
           if (document.forms[0].elements['optAct1'].checked==true) {
               intOpcAct = "1";    
           }
           if (document.forms[0].elements['optAct2'].checked==true) {
               intOpcAct = "2";    
           }
           
           document.forms[0].action = "<%=strFormAction%>?strCmd=RemplazarArticulo" + "&intproveedorDestinoId=" + "<%=intproveedorDestinoId%>" +  "&strProveedorDestinoNombreId=" + "<%=strProveedorDestinoNombreId%>" + "&strProveedorDestinoRazonSocial=" + "<%=strProveedorDestinoRazonSocial%>" + "&intOpcAct=" + intOpcAct;
           document.forms[0].target="ifrOculto";
           document.forms[0].submit();
           document.forms[0].target='';      
       }
       
   }
   
}

function cmdAgregar_onclick() {
   
   if (blnEntradaValida()) {
   
       var intOpcAct = "";
       if (document.forms[0].elements['optAct1'].checked==true) {
           intOpcAct = "1";    
       }
       if (document.forms[0].elements['optAct2'].checked==true) {
           intOpcAct = "2";    
       }
  
       document.forms[0].action = "<%=strFormAction%>?strCmd=AgregarArticulo" + "&intproveedorDestinoId=" + "<%=intproveedorDestinoId%>" +  "&strProveedorDestinoNombreId=" + "<%=strProveedorDestinoNombreId%>" + "&strProveedorDestinoRazonSocial=" + "<%=strProveedorDestinoRazonSocial%>" + "&intOpcAct=" + intOpcAct;
       document.forms[0].target="ifrOculto";
       document.forms[0].submit();
       document.forms[0].target='';      
   }
  
}

function fnUpAgregarArticulo(intError,intContadorAlta) {
	if (intError==-100) {
       alert("No se pudo abrir o no existe el archivo de carga");
	}
	if (intError==-110) {
       alert("Los registros del archivo no cumplen con la estructura (solo el número de articulo).");
	}
	if (intError==-120) {
       alert("Algun registro contiene un articulo no valido");
	}
	if (intError==-200) {
       alert("No se pudieron obtener los articulos del proveedor origen");
	}
	
	if (intContadorAlta>0) {
	  alert("Se agregaron/actualizaron [" + intContadorAlta + "] registros");   
    }
    else {
       alert("No se dio ningun articulo de alta");
    }
    
   document.forms(0).hdnFolioActualCarga.value='';
   document.forms(0).hdnProveedorId.value = '';		
   document.forms(0).hdnProveedorNombreId.value = '';
   document.forms(0).txtProveedorNombreId.value = '';
   document.forms(0).txtProveedorRazonSocial.value='';   
       
   document.forms[0].action = "<%=strFormAction%>?intproveedorDestinoId=" + "<%=intproveedorDestinoId%>" +  "&strProveedorDestinoNombreId=" + "<%=strProveedorDestinoNombreId%>" + "&strProveedorDestinoRazonSocial=" + "<%=strProveedorDestinoRazonSocial%>"
   document.forms[0].target='';  
   document.forms[0].submit();
       	
}

function cmdRegresar_onclick() {
    window.location="SucursalProveedoresConsultar.aspx"
}

//-->
		</script>
</HEAD>
<body language="javascript" onLoad="return window_onload()">
<form method="post" id="frmMain" name="frmMain" enctype="multipart/form-data" runat="server">
  <table cellspacing="0" cellpadding="0" width="780" border="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script>
      </td>
    </tr>
  </table>
  <table cellspacing="0" cellpadding="0" width="780" border="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td class="tdtab" width="770">Está en : <a href="SucursalHome.aspx">Sucursal</a> :<a href="SucursalMercancias.aspx">Mercancias</a>:<a href="SucursalMercanciasProveedores.aspx">Proveedores</a>:<a href="SucursalProveedoresConsultar.aspx">Proveedores
          Consultar</a>:Modificar Articulos Autorizados</td>
    </tr>
  </table>
  <table cellspacing="0" cellpadding="0" width="780" border="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Modificar articulos autorizados</h1>
        <p>En esta parte se puede modificar o crear la lista de articulos autorizados
          para el proveedor especifico, desde un archivo o desde otro proveedor.</p>
        <table cellspacing="0" cellpadding="0" width="100%" border="0">
          <tr>
            <td width="2%">&nbsp;</td>
            <td width="88%" class="tdtexttablebold" valign="top"><span class="txsubtitulo">Proveedor
                : <%= strProveedorDestinoNombreId%> - <%= strProveedorDestinoRazonSocial%> </span></td>
          </tr>
        </table>
        <table cellspacing="0" cellpadding="0" width="100%" border="0">
          <tr>
            <td class="tdtexttablebold" width="5%"><input type="radio" value="1" name="optAct" id="optAct1" language="javascript">
            </td>
            <td class="tdtexttablebold" width="20%">Archivo:</td>
            <td class="tdtexttablebold" width="75%"><input name="txtArticulosArchivo" type="file" class="campotabla" id="txtArticulosArchivo"
										size="35" title="Archivo" runat="server" language="javascript" onfocus="return txtArticulosArchivo_onfocus()">
&nbsp; <a id="objPrevioCarga" onClick="objPrevioCarga_onclick()"><IMG height="17" width="17" src="../static/images/imgNRPrevio.gif" align="absMiddle"
											border="0"></a> </td>
          </tr>
          <tr>
            <td class="tdtexttablebold" width="5%"><input type="radio" value="2" name="optAct" id="optAct2" language="javascript">
            </td>
            <td class="tdtexttablebold" width="20%">Desde el proveedor:</td>
            <td class="tdtexttablebold" width="75%"><input name="txtProveedorNombreId" id="txtProveedorNombreId" type="text" class="campotabla" value='<%=Request.Form("txtProveedorNombreId")%>'  autocomplete="off" size="16" maxLength="16"  language="javascript" onblur="return txtProveedorNombreId_onblur()" onkeydown="txtProveedorNombreId_onKeyDown()" onfocus="return txtProveedorNombreId_onfocus()">
&nbsp; <a id="objLupaProveedor" onClick="objLupaProveedor_onclick()"><IMG height="17" src="../static/images/icono_lupa.gif" width="17" align="absMiddle" border="0"></a>&nbsp;<a id="objLupaArticulo" onClick="objLupaArticulo_onclick()"><IMG height="17" src="../static/images/imgNRVerA.gif" width="17" align="absMiddle" border="0"></a>&nbsp; <span class="txconttablasrojo">
              <input class="campotablaresultado" id="txtProveedorRazonSocial" readOnly maxLength="46" size="46" border="0" name="txtProveedorRazonSocial" value='<%=Request.Form("txtProveedorRazonSocial")%>' >
              </span> </td>
          </tr>
          <tr>
            <td colspan="2" height="10"><img height="10" src="images/pixel.gif" width="1"></td>
          </tr>
        </table>
        <input class="boton" id="cmdRegresar" type="button" value="Regresar" name="cmdRegresar"
							language="javascript" onclick="return cmdRegresar_onclick()">
&nbsp;
        <input class="boton" id="cmdRemplazar" type="button" value="Remplazar" name="cmdRemplazar"
							language="javascript" onclick="return cmdRemplazar_onclick()">
&nbsp;
        <input class="boton" id="cmdAgregar" type="button" value="Agregar" name="cmdAgregar" language="javascript"
							onclick="return cmdAgregar_onclick()">
        <br>
        <%=strConsultarArticulos%> <br>
        <div id="divRB" style="DISPLAY: none"></div>
      </td>
    </tr>
  </table>
  <table cellspacing="0" cellpadding="0" width="780" border="0">
    <tr>
      <td><script language="JavaScript">crearTablaFooterCentral()</script>
      </td>
    </tr>
    <tr>
      <input type='hidden' name='hdnFolioActualCarga' value='<%=Request.Form("hdnFolioActualCarga")%>' >
      <input type='hidden' name='hdnProveedorId' value= '<%=Request.Form("hdnProveedorId")%>'>
      <input type='hidden' name='hdnProveedorNombreId' value= '<%=Request.Form("hdnProveedorNombreId")%>'>
    </tr>
  </table>
  <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	//-->
			</script>
</form>
<iframe name="ifrOculto" src="" width="0" height="0"></iframe>
<iframe name="ifrPageToPrint" src="../static/PageToPrint.htm" width="0" height="0"> </iframe>
</body>
</HTML>
