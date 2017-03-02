<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaConsultarMaximosProductos.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaConsultarMaximosProductos" codePage="28592"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<title>Sistema Administrador de Sucursal</title><html>
<head>
<%  '====================================================================
    ' Page          : MercanciaConsultarMaximosProductos.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página para consultar los máximos de artículos.
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Carlos E. Pérez Torres
    ' Version       : 1.0
    ' Last Modified : Martes Noviembre 18, 2003
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link rel="stylesheet" href="../static/css/menu.css">
<link rel="stylesheet" href="../static/css/menu2.css">
<link rel="stylesheet" href="../static/css/estilo.css">
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--
var strPaginaAyuda
strPaginaAyuda = "";


function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}

function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}

function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
}

function window_onload() {
		MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
		document.forms[0].action = "<%=strFormAction%>"; 

         document.forms[0].elements['txtArticuloId'].value="<%=Request.Form("txtArticuloId")%>";
         document.forms[0].elements['txtArticuloDescripcion'].value="<%=Request.Form("txtArticuloDescripcion")%>";         

        strCmd = "<%=strCmd()%>";

        if (strCmd == "Limpiar"){
			document.forms[0].elements['txtArticuloId'].value='';
			document.forms[0].elements['txtArticuloDescripcion'].value='';			
        }
            
		if (strCmd=="Ver"){
		
		    resultado="<%=strBuscarArticuloDescripcion%>";
		
		    if (resultado!="0"){
			      document.forms[0].elements['txtArticuloId'].value="<%=strArticuloInternoId%>";
		          document.forms[0].elements['txtArticuloDescripcion'].value="<%=strArticuloNombreId%>";
		     }
		     
		     else {
		      
		        alert("Codigo Articulo No existe")
		     }
		}
		else {
			document.forms[0].elements['txtArticuloId'].focus();
		}
         

         return(true);
}

function cmdDetectaNumero_onClick(){
	if (document.forms[0].elements['txtArticuloId'].value!=""){
      if (!isNaN(document.forms[0].elements['txtArticuloId'].value)) {
	  
	       	       if (document.forms[0].elements['hdnArticuloId'].value != document.forms[0].elements['txtArticuloId'].value){
                			document.forms[0].action = "<%=strFormAction%>?strCmd=Ver";
                			document.forms[0].target= "ifrOculto";
                			document.forms[0].submit();
                			document.forms[0].target= "";
                			return(false);
					}		
	  }
	  else {
	                
			cmdBuscarArticulo_onClick("PopArticulo.aspx?strArticuloIdNombre=" + document.forms(0).elements('txtArticuloId').value + "&strArticulo=txtArticuloId&strArticuloNombreId=txtArticuloDescripcion",500,540);
	  }
	}
	else {
		alert("Teclear Código o Descripcion");
        return false;
	}
	
}

function cmdBuscarArticulo_onClick(url, width, height) {
          url=url+'&strArticuloBuscar='+document.forms[0].elements['txtArticuloId'].value;
          return Pop(url, width, height);
}
 
function Pop(url, width, height) {
    var Win = window.open(url,'Pop','width=' + width + ',height=' + height + ',left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no' );
	 return (false);
}


// Despliegue basico 
function strCompaniaSucursal() {
	document.write(<%=intCompaniaId%> + " - " + <%=intSucursalId%>);
	return(true);
}

function strSucursalNombre() {
	document.write("&nbsp;"+"<%=strSucursalNombre%>");
	return(true);
}

function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")%>");
	return(true);
}

function strUsuarioNombre() {
	document.write("<%=strUsuarioNombre%>");
	return(true);
}

//Salir
function btnSalir_onclick() {
	document.location = 'MercanciaInventariosMaximosDeProductos.aspx';
	return(true);
}

//RecordBrowser
function strRecordBrowserHTML(){
 document.write("<%=strRecordBrowserHTML%>");
 return(true);
}

// Botones
function strGeneraBotonesHTML(){
 document.write("<%=strGeneraBotonesHTML%>");
 return(true);
}

// Regresa hacia el Home
function cmdRegresar_onClick(){
 document.location ='MercanciaInventariosMaximosDeProductos.aspx';
 return(true);
}

// Reinicia la consulta
function cmdLimpiar_onClick(){
 document.forms[0].action = "<%=strFormAction%>?strCmd=Limpiar";
 document.forms[0].submit();
 return(true);
}

// Va a pagina de sugerir maximos
function cmdSugerir_onClick(){
 document.forms[0].action = "MercanciaCapturarMaximoSugerido.aspx?strCmd=ConsultarMaximos&txtIntArticuloId="+document.forms[0].elements['txtArticuloId'].value;
 document.forms[0].submit();
 return(true);
}

// Impresion de datos
function cmdImprimir_onClick(){
 printContent();
 return(true);
}

function cmdConsultar_onclick() {
   var valida=true;
   
   
   if (document.forms[0].elements['cmdConsultar'].value == 'Consultar') {
       var blnConsultaArticulo = true;
 
        if (document.forms[0].elements['txtArticuloId'].value == 0) {
           alert("Capturar el codigo de articulo");
           valida=false;
           }
           
         if (parseInt(document.forms[0].elements['txtArticuloId'].value) < 0) {
           alert("Capturar correctamente el codigo de articulo");
           valida=false;
           }
           
        if (isNaN(document.forms[0].elements['txtArticuloId'].value)) {
              blnConsultaArticulo = true;   
                
              var url = "PopArticulo.aspx?strArticuloIdNombre=" + document.forms(0).elements('txtArticuloId').value + "&strArticulo=txtArticuloId&strArticuloNombreId=txtArticuloDescripcion";
          
              Pop(url, 400, 540);  
              return(false);              
            }   
            
        intLongitud = document.forms[0].elements['txtArticuloId'].value;
        intLongitud = intLongitud.length;
        
        if (intLongitud > 8){
            blnConsultaArticulo = true;
          }
        else{
            blnConsultaArticulo = false;          
        }                         


         if (blnConsultaArticulo) {
             document.forms[0].action="<%=strFormAction%>?strCmd=Ver";
             document.forms[0].target="ifrOculto";
            }
         else{       
              document.forms[0].action="<%=strFormAction%>?strCmd=Consultar";
             }
             
          document.forms[0].submit();
          document.forms[0].target='';
          
  } 
 return(valida);
}

function txtArticuloId_onfocus() {
 document.forms[0].elements['txtArticuloId'].select();
}

//-->
</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0"  onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaConsultarMaximosProductos">
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
            <td width="583" class="tdmigaja"><div id="ToPrintTxtMigaja"><span class="txdmigaja">Está 
                en : </span><a href="Mercancia.aspx" class="txdmigaja">Mercancía</a><span class="txdmigaja"> 
                : <a href="MercanciaInventarios.aspx" class="txdmigaja">Inventarios</a></span><span class="txdmigaja"> 
                </span><span class="txdmigaja">: </span><span class="txdmigaja"> 
                </span><span class="txdmigaja"><a href="MercanciaInventariosMaximosDeProductos.aspx" class="txdmigaja">Máximos 
                por producto </a></span><span class="txdmigaja">:</span><span class="txdmigaja"> 
                Consultar máximos por producto</span></div></td>
            <td width="182" class="tdfechahora"> <script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top"><table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="100%" colspan="3" valign="top" class="tdtablacont"> 
                    <p><span class="txtitulo">Consultar máximos por producto</span><span class="txcontenido">Para 
                      consultar el máximo de un producto, introduzca su clave 
                      y oprima "Consultar". Si desea agregar el producto a una 
                      sugerencia de máximo, oprima "Sugerir máximo"’.<br>
                      <br>
                      </span><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">Máximo 
                      de producto</span> 
                      <script language="JavaScript">crearDatosSucursal()</script><br>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                      <tr> 
                        <td width="50" class="tdtittablas">Código:</td>
                        <td width="81" class="tdpadleft5"><input name="txtArticuloId" type="text" class="campotabla" size="16" onKeyDown="if (event.keyCode==13){document.forms[0].elements['imgLupa'].click();} if (event.keyCode==9){document.forms[0].elements['imgLupa'].click();}" onFocus="return txtArticuloId_onfocus()"> 
                        </td>
                        <td width="32" class="tdpadleft5"> <a href="javascript:;" onClick="return cmdDetectaNumero_onClick();"><img src="../static/images/icono_lupa.gif" width="17" height="17" align="absMiddle" border="0" id="imgLupa"></a></td>
                        <td width="372" class="tdconttablasrojo"><input class="campotablaresultado" type="text" size="50" name="txtArticuloDescripcion" readonly> 
                          <input type="hidden" name="hdnArticuloId"> </td>
                      </tr>
                    </table>
                    <br> <input name="cmdConsultar" type="button" class="boton" id="cmdConsultar" value="Consultar" onClick="return cmdConsultar_onclick()"> 
                    <br> <br> <br> <div id="ToPrintHtmContenido"> 
                      <script language="JavaScript">strRecordBrowserHTML()</script>
                    </div>
                    <br> <script language="JavaScript">strGeneraBotonesHTML()</script> 
                    <br> <p></p></td>
                </tr>
              </table></td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader"> <script language="javascript">strGeneraTablaAyuda('');</script> 
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
	new menu (MENU_ITEMS, MENU_POS);
	new menu (MENU_ITEMS2, MENU_POS2);
	//-->
</script>
  <iframe name="ifrPageToPrint" src="../static/PageToPrint.htm" width="0" height="0"></iframe>
  <iframe name="ifrOculto" width="0" height="0"></iframe>
</form>
</body>
</html>
