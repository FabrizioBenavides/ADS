<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaCapturaInventarioLibre.aspx.vb" Inherits="com.isocraft.backbone.ccentral.MercanciaCapturaInventarioLibre" codePage="28592"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%  '====================================================================
    ' Page          : MercanciaCapturaInventarioLibre.aspx
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%>
<link href="../static/css/menu.css" rel="stylesheet">
<link href="../static/css/menu2.css" rel="stylesheet">
<link href="../static/css/estilo.css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/scripts/calendar1.js"></script>
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">
<!--

function LTrim(s){
	// Devuelve una cadena sin los espacios del principio
	var i=0;
	var j=0;
	
	// Busca el primer caracter <> de un espacio
	for(i=0; i<=s.length-1; i++)
		if(s.substring(i,i+1) != ' '){
			j=i;
			break;
		}
	return s.substring(j, s.length);
}

function RTrim(s){
	// Quita los espacios en blanco del final de la cadena
	var j=0;
	
	// Busca el último caracter <> de un espacio
	for(var i=s.length-1; i>-1; i--)
		if(s.substring(i,i+1) != ' '){
			j=i;
			break;
		}
	return s.substring(0, j+1);
}

function Trim(s){
	// Quita los espacios del principio y del final
	return LTrim(RTrim(s));
}

function strEliminacommas(objcampo) {
 // Quita las comas 
   while (parseInt(objcampo.search(',')) > 0){
          objcampo = objcampo.replace(',','');
         }
  
  // quita el signo de pesos
  objcampo = objcampo.replace('$','');  
  return(objcampo);
}

function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
	return(true);
}

function Pop(url, width, height) {
    var Win = window.open(url,'Pop','width=' + width + ',height=' + height + ',left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no' );
	return(false);
}

function window_onload() {
   MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
   document.forms[0].action = "<%=strFormAction%>";
   
   if (document.forms[0].elements['hdnRegistros'].value == 0) {
       document.all.tblRegistrar.style.display='none';
   }
   else {
       document.all.tblRegistrar.style.display='';
   }
       
   document.forms[0].elements['txtArticuloId'].focus();      
   
   return(true);            
}

function objArticuloLupa_onClick() {
   if (document.forms[0].elements['txtArticuloId'].value!="") {
       if ( !isNaN(document.forms[0].elements['txtArticuloId'].value) ) {
           // Es un numero
           if (document.forms[0].elements['txtArticuloId'].value != '0') {               
               document.forms[0].action = "<%=strFormAction%>?strCmd=BuscarArticulo";
               document.forms[0].target="ifrOculto";
               document.forms[0].submit();			       
  		       document.forms[0].target='';
               return(true);
           }
       }
       else {
           // Es una descripcion
           document.forms[0].elements['txtDescripcionArticulo'].value=''; 
           
		   strEvalJs="if(opener.document.forms[0].elements['txtArticuloId'].value!='0'){opener.objArticuloLupa_onClick()}";
		   strParametros='';
		   strParametros=strParametros + '?strArticuloIdNombre=' + document.forms[0].elements['txtArticuloId'].value;
		   strParametros=strParametros + '&strArticuloNombreId=txtDescripcionArticulo' 
		   strParametros=strParametros + '&strArticulo=txtArticuloId' 
		   Pop('PopArticulo.aspx'+strParametros+'&strEvalJs='+strEvalJs,500,540);
       }
   }
   else {
       alert("Teclear número de artículo o descripción");
	   document.forms(0).txtArticuloId.focus();
       return(false);    
   }
}

function txtArticuloId_onblur() {
   if(Trim(document.forms[0].elements['txtArticuloId'].value)=='') {
       document.forms[0].elements['txtArticuloId'].value = '';
       document.forms[0].elements['hdnArticuloId'].value = '';       
       document.forms[0].elements['txtDescripcionArticulo'].value = '';
       return;
   }
   	
   if(document.forms[0].elements['txtArticuloId'].value != document.forms[0].elements['hdnArticuloId'].value) {
       objArticuloLupa_onClick();		
   }
   else {
       document.forms[0].elements['txtExistencia'].focus(); 
   }
   
}

function objLupaArticulo_onclick() {
   txtArticuloId_onblur();
}

function txtExistencia_onblur() {
    document.forms(0).cmdAgregar.focus(); 
}

function txtCifraControl_onKeyDown(){
	if(event.keyCode==13){ document.forms(0).cmdRegistrar.click(); }
}

function cmdImprimir_onclick() {
   if (document.forms[0].elements['txtInventarioFolio'].value > 0) {
       document.ifrPageToPrint.focus();
       window.print(); 
   }
}

function cmdRegresar_onclick() {
  document.location.href='MercanciaInventariosCapturaLibre.aspx';
}

// Agrega el Articulo al detalle
function intAgregaRegistro() {
    document.forms[0].action = "<%=strFormAction%>?strCmd=AgregarArticulo&intArticuloAgregarId=" + document.forms[0].elements['txtArticuloId'].value; 
    document.forms[0].target="ifrOculto";
    document.forms[0].submit();
    document.forms[0].target='';  
}
// Elimina el Articulo seleccionado del detalle
function intEliminaRegistro(intArticuloEliminar) {
    if (document.forms[0].elements['txtInventarioFolio'].value < 1) {
       document.forms[0].action = "<%=strFormAction%>?strCmd=EliminarArticulo&intArticuloEliminarId=" + intArticuloEliminar;
       document.forms[0].target="ifrOculto";
       document.forms[0].submit();
       document.forms[0].target='';    
    }
}

function cmdRegistrar_onclick() {   
   var intCifraControlCalulado  = document.forms[0].elements['hdnCifraControl'].value;
   var intCifraControlCapturada = document.forms[0].elements['txtCifraControl'].value;
    
   if (intCifraControlCalulado == intCifraControlCapturada) {
       document.forms[0].action = "<%=strFormAction%>?strCmd=RegistrarInventario";
       document.forms[0].target="ifrOculto";
       document.forms[0].submit();
       document.forms[0].target='';   
   }
   else {
       alert("La Cifra de Control no coincide con la sumatoria de la Existencia Real, favor de verificar la información.");
   }   
}

function fnUpAccionInventarios(intAccion, strRecordBrowserHTML, intArticuloBuscadoId, strArticuloBuscadoDescripcion, intInventarioId, intTotalRegistrosCapturados, intTotalExistenciasCapturadas, intInventarioFolio, intResultadoAccion ) {
      
   document.forms[0].elements['hdnInventarioId'].value = intInventarioId;
   document.forms[0].elements['hdnRegistros'].value = intTotalRegistrosCapturados;
   document.forms[0].elements['hdnCifraControl'].value = intTotalExistenciasCapturadas;
   document.forms[0].elements['hdnInventarioFolio'].value = intInventarioFolio;

   document.forms[0].elements['txtInventarioFolio'].value = intInventarioFolio;   
   document.forms[0].elements['txtArticuloId'].value = '';
   document.forms[0].elements['txtDescripcionArticulo'].value = '';	 
   document.forms[0].elements['txtExistencia'].value = '';	   
   
   if (document.forms[0].elements['hdnRegistros'].value < 1) {
       document.all.tblRegistrar.style.display='none'; 
   }
   else {
       document.all.tblRegistrar.style.display=''; 
   } 
   
   if (intAccion == 3) {  
       document.ifrPageToPrint.document.all.divContenido.innerHTML= strRecordBrowserHTML;    
   }
   else {
       document.all.strRecordBrowserHTML.innerHTML = strRecordBrowserHTML;
   }
      
   if (intAccion == 0) { // Busqueda de Articulo   
       if (intResultadoAccion == 1) {
           document.forms[0].elements['txtArticuloId'].value = intArticuloBuscadoId;
           document.forms[0].elements['txtDescripcionArticulo'].value = strArticuloBuscadoDescripcion;	                    	   
           document.forms[0].elements['txtExistencia'].focus();	
       } 
       else {
           alert ("El Código del Artículo no fue encontrado");           
           document.forms[0].elements['txtArticuloId'].focus();	
       }      
   }
      
   if (intAccion == 1) { // Agregar Articulo   
       if (intResultadoAccion == -100) {
           alert("Error Fatal al agregar el Código del Artículo.");
       } 
       if (intResultadoAccion == -120) {
           alert("El Código del Artículo no es un número válido.");
       } 
       if (intResultadoAccion == -121) {
           alert("El valor de la Existencia no es un número válido.");
       } 
       if (intResultadoAccion == -122) {
           alert("El Artículo ya se encuentra dato de alta en un Inventario Rotativo para el día de hoy.");
       }        
       if (intResultadoAccion == -123) {
           alert("El Artículo ya se encuentra dato de alta en otro Inventario Libre para el día de hoy.");
       } 
       document.forms[0].elements['txtArticuloId'].focus();
   }
   
   if (intAccion == 2) { // Eliminar Articulo
       if (intResultadoAccion == -100) {
           alert("El Artículo no pudo eliminarse.");
       } 
       document.forms[0].elements['txtArticuloId'].focus();
   }
   
   if (intAccion == 3) { // Registrar Inventario
       if (intResultadoAccion == 1) {
           document.all.tblArticulo.style.display='none'; 
           
           document.forms[0].elements['cmdRegistrar'].disabled=true;
		   document.forms[0].elements['cmdRegistrar'].title='El Inventario ya fue registrado.';
		   document.forms[0].elements['txtCifraControl'].readOnly=true;
		   document.forms[0].elements['txtCifraControl'].className="campotabladeshabilitado";
		   document.forms[0].elements['txtCifraControl'].title='El Inventario ya fue registrado.';
		   document.forms[0].elements['cmdAgregar'].disabled=true;
		   document.forms[0].elements['cmdAgregar'].title='El Inventario ya fue registrado.';
           		   
		   msg = "Inventario Registrado con el Folio : [" + intInventarioFolio + "]";           
		   if (confirm (msg + "\n ¿Desea imprimir el Reporte de Diferencias ahora?")) {               
		   	   document.ifrPageToPrint.focus();
	           window.print();               
		   }		   
       }
       else {
           alert("Inventario no pudo Registrarse");
       }
       document.forms[0].elements['cmdRegresar'].focus();   
   }   

}


function cmdAgregar_onclick() {
intAgregaRegistro();
}
//-->
</script>
</HEAD>
<body leftMargin="0" topMargin="0" marginwidth="0" marginheight="0" onload="return window_onload()">
<form name="frmMercanciaCapturarInventarioLibre" action="about:blank" method="post">
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
                en :</span><span class="txdmigaja"> <a href="Mercancia.aspx" class="txdmigaja">Mercancía</a> 
                : <a href="MercanciaInventarios.aspx" class="txdmigaja">Inventarios</a> 
                : <a href="MercanciaInventariosCapturaLibre.aspx" class="txdmigaja">Inventario 
                Libre</a> : Captura</span></div></td>
            <td width="182" class="tdfechahora"> <script language="JavaScript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td vAlign="top" width="583"> <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                <tr> 
                  <td class="tdtablacont" vAlign="top" width="75%"> <p><span class="txtitulo">Capturar 
                      Inventario Libre</span> <span class="txcontenido">&nbsp;Capture 
                      el código&nbsp; y la cantidad del conteo de cada uno de 
                      los productos del Inventario Libre, oprima "Agregar" para 
                      cada uno de los códigos. Al finalizar oprima&nbsp;"Registrar 
                      Inventario"&nbsp;</span><br>
                    </p>
                    <script language="JavaScript">crearDatosSucursal()</script> 
                    <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                      <tr> 
                        <td height="27" class="tdtittablas">Folio:</td>
                        <td class="tdpadleft5" vAlign="middle"> <input class="campotabladeshabilitado" readOnly type="text" size="16" name="txtInventarioFolio"> 
                        </td>
                      </tr>
                    </table>
                    <br> <div id="strRecordBrowserHTML" name="strRecordBrowserHTML"></div>
                    <br> <span class="txsubtitulo"> <img height="11" src="../static/images/bullet_subtitulos.gif" width="17" align="absMiddle">Detalles 
                    de articulo</span> <table id="tblArticulo" class="tdenvolventetablas" width="100%">
                      <tr> 
                        <td class="tdtittablas3" align="left" width="120">Código</td>
                        <td class="tdtittablas3" align="left" width="60">Existencia</td>
                        <td class="tdtittablas3" align="left" width="240">Descripción</td>
                        <td vAlign="middle" width="50" rowspan="2" align="center"> 
                          <input class="boton" type="button" id="cmdAgregar" value="Agregar" name="cmdAgregar" onclick="return cmdAgregar_onclick()"> 
                        </td>
                      </tr>
                      <tr> 
                        <td class="txtitintabla" vAlign="middle" width="120" height="20"> 
                          <input class="campotablahabilitadoderecha" type="text" id="txtArticuloId" name="txtArticuloId"
																autocomplete="off" maxLength="16" size="16" onkeydown="if(event.keyCode==13){txtArticuloId_onblur();}"
																onblur="txtArticuloId_onblur();"> 
                          <a id="objLupaArticulo" onclick="return objLupaArticulo_onclick()"> 
                          <img height="17" src="../static/images/icono_lupa.gif" width="16" align="absMiddle" border="0"></a> 
                        </td>
                        <td class="tdpadleft5" vAlign="middle" width="60"> <input class="campotablahabilitadoderecha" type="text" id="txtExistencia" name="txtExistencia"
																autocomplete="off" maxLength="8" size="12" onkeydown="if(event.keyCode==13){document.forms[0].elements['cmdAgregar'].focus();}"
																onblur="return txtExistencia_onblur()"> 
                        </td>
                        <td class="txtitintabla" vAlign="middle" width="240"> 
                          <input class="campotablaresultadoenvolventeazul" type="text" name="txtDescripcionArticulo"
																readOnly size="30"> 
                        </td>
                      </tr>
                    </table>
                    <br> <table id="tblCifraControl" cellSpacing="0" cellPadding="0" width="100%" height="30" border="0">
                      <tr> 
                        <td width="280" height="30"><input class="boton" type="button" value="Regresar" name="cmdRegresar" onclick="return cmdRegresar_onclick()"> 
                          <input class="boton" type="button" value="Imprimir Diferencias" name="cmdImprimir" onclick="return cmdImprimir_onclick()"> 
                        </td>
                        <td class="tdenvolventetablas" align="center" width="200" bgColor="#f4f6f8" id="tblRegistrar"> 
                          <table border="0" cellSpacing="0" cellPadding="0" width="230">
                            <tr> 
                              <td class="tdtittablas3" width="156">Cifra de control</td>
                              <td width="91" rowSpan="2"> <input class="boton" type="button" name="cmdRegistrar" value="Registrar" onclick="return cmdRegistrar_onclick()"> 
                              </td>
                            </tr>
                            <tr> 
                              <td vAlign="top"> <input class="campotabla" type="text" name="txtCifraControl" onkeydown="txtCifraControl_onKeyDown()"
																			maxLength="4" size="16"> 
                              </td>
                            </tr>
                          </table></td>
                      </tr>
                    </table></td>
                </tr>
              </table></td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader">&nbsp;</td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script> 
            </td>
          </tr>
        </table></td>
    </tr>
  </table>
  <tr> 
    <input type='hidden' value='<%=Request.Form("hdnArticuloId")%>' name='hdnArticuloId'>
    <input type='hidden' value='<%=Request.Form("hdnInventarioId")%>' name='hdnInventarioId'>
    <input type='hidden' value='<%=Request.Form("hdnRegistros")%>' name='hdnRegistros'>
    <input type='hidden' value='<%=Request.Form("hdnCifraControl")%>' name='hdnCifraControl'>
    <input type='hidden' value='<%=Request.Form("hdnInventarioFolio")%>' name='hdnInventarioFolio'>
  </tr>
  <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	new menu (MENU_ITEMS2, MENU_POS2);
	//-->
			</script>
</form>
<iframe name="ifrOculto" src width="0" height="0"></iframe>
<iframe name="ifrPageToPrint" src="ifrPaginaenBlanco.aspx" width="100%" height="0" marginheight="0"
			marginwidth="0"></iframe>
</body>
</HTML>
