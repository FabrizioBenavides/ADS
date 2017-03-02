<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" enableViewState="False" Explicit="True" Trace="False" Strict="True" CodeBehind="popVentasPromocionesMonederoAgregar.aspx.vb"      Inherits="com.isocraft.backbone.ccentral.popVentasPromocionesMonederoAgregar" codePage="28592" %>
<HTML>
<HEAD>
<title>Benavides : Administrador de Puntos de Venta</title>
<%  '====================================================================
    ' Page          : popVentasPromocionesMonederoAgregar.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : 
    ' Copyright     : 2007
    ' Company       : Farmacias Benavides
    ' Author        : J.Antonio Hernandez    
    ' Last Modified : 01 Noviembre 2007
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link href="css/estilo.css" type="text/css" rel="stylesheet">
<script language="JavaScript" src="js/calendario.js"></script>
<script language="JavaScript" src="js/cal_format00.js"></script>
<script language="JavaScript" src="js/Validator.js"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--


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
	
	document.forms[0].elements['cmdContinuar'].disabled=false;
	document.forms[0].elements['txtPromocionNombre'].focus(); 
	return(true);
}


function cmdCerrar_onclick() {	
	window.close();	
	return(true);
}

function cmdContinuar_onclick(blnAgregarPromocion) {
    
    var continuar = true;
	document.forms[0].elements['cmdContinuar'].disabled=true;
	
	// Validacion de Nombre de la promocion
	if (document.forms[0].elements['txtPromocionNombre'].value.length==0) {
	    alert('Capturar el nombre con el cual se identificar la promoci�n');
		continuar = false;		
	}
	
	var formato=/^[A-Z,a-z,0-9, ,_]{1,50}$/;
	
    if(continuar && !(formato.test(document.forms[0].elements["txtPromocionNombre"].value)) ) {
        alert('El nombre capturado contiene caracteres no validos eliminelos' );
		continuar = false;
	}
	
	// Validacion de Tipo de promocion
	if (continuar && (document.forms[0].elements['txtTipoPromocion'][0].checked == false && document.forms[0].elements['txtTipoPromocion'][1].checked== false)) {
	    alert('Capturar el Tipo de promoci�n');
		continuar = false;		
	}
	
    //validacion de fechas
    if (continuar && (document.forms[0].elements['txtPromocionInicio'].value.length==0 || document.forms[0].elements['txtPromocionFin'].value.length==0)) {
        alert('Favor de capturar el rango de la vigencia.'); 
		continuar = false;
	}
			 	 
	if (continuar && ( document.forms[0].elements['txtPromocionInicio'].value.length>0 && document.forms[0].elements['txtPromocionFin'].value.length>0 ) )	 {
	   if (continuar && validateDate(document.forms[0].txtPromocionInicio,'dd/MM/yyyy')==false)	{
	       continuar = false;
	   }
	   if (continuar && validateDate(document.forms[0].txtPromocionFin,'dd/MM/yyyy')==false)	{
	       continuar = false;
	   }	
	   if (continuar && validateStartAndEndDate("txtPromocionInicio","txtPromocionFin",'dd/MM/YYYY')==false) {
           alert('La Fecha de Fin  debe ser mayor o igual que la de Inicio.\nFavor de verificar  el rango de las fechas.'); 
		   continuar = false;
	   }
	}
    
	if (continuar) {
	    document.forms(0).action = '<%=strFormAction%>?strCmd=AgregarPromocion&blnAgregarPromocion=' + blnAgregarPromocion ;
		document.forms(0).target = 'ifrOculto';
		document.forms(0).submit();       
    }
	else {
       document.forms[0].elements['cmdContinuar'].disabled=false;
       document.forms[0].elements['txtPromocionNombre'].focus();
	}
}

function fnUpdPromocionPorIframe(intError, intPromocionId, strPromocionNombre, dtmPromocionInicio, dtmPromocionFin,strTipoPromocion,strEstadoPromocion) {
   
   var par = "intPromocionId=" + intPromocionId + "&strPromocionNombre=" + strPromocionNombre + "&dtmPromocionInicio=" + dtmPromocionInicio +  "&dtmPromocionFin=" + dtmPromocionFin +  "&strTipoPromocion=" + strTipoPromocion  +  "&strEstadoPromocion=" + strEstadoPromocion ; 
   var url = '';
      
   if  (intError == 0) {
       if (strTipoPromocion=='ARTICULO') {
           url = 'popVentasPromocionesMonederoDetalleArticulo.aspx?' + par;       
       }
       else{
           url = 'popVentasPromocionesMonederoDetalleCategoria.aspx?' +par;
       }
	   	   
	   document.forms[0].action = url;
	   document.forms[0].target ='';
	   document.forms[0].submit();       
   }
   else
   {
       document.forms[0].elements['cmdContinuar'].disabled=false;
       if (intError == -99) {
           if (confirm ('Ya existe una promoci�n con el mismo nombre, continuar') )  {		   
               cmdContinuar_onclick(1);
           }
       }   
   }
      
}

//-->
</script>
</HEAD>
<body language="javascript" onLoad="return window_onload()">
<form name="frmPromocionesMonederoAgregar" action="about:blank" method="post" >
  <table height="580" width="700" cellspacing="0" cellpadding="0" border="0">
    <tr> 
      <td width="2%"></td>
      <td width="96%"> <table width="60%" align="center">
          <tr> 
            <td class="tdlogopop" height="21"> <img height="54" src="../static/images/logo_pop.gif" width="177"></td>
          </tr>
        </table>
        <table width="60%" align="center" class="tdEnvolventeTablaAzul">
          <tr> 
            <td valign="top" height="30"  colspan="2"><h1>Agregar Promoci�n Monedero</h1>
              <p> En esta parte se dan de alta las promociones de monedero</p></td>
          </tr>
          <tr> 
            <td width="20%" class="tdtexttablebold" valign="middle" >Nombre</td>
            <td width="60%" valign="middle"><input class="field" id="txtPromocionNombre" type="text" autocomplete="off"  maxlength="50" size="50" name="txtPromocionNombre"  value='<%=Request("txtPromocionNombre")%>'> 
            </td>
          </tr>
          <tr> 
            <td width="20%" class="tdtexttablebold" valign="middle" >Tipo</td>
            <td width="60%" class="tdtexttablebold" valign="middle"><input type="radio" value="0" name="txtTipoPromocion" >
              Categoria &nbsp;&nbsp; <input type="radio" value="1" name="txtTipoPromocion">
              Articulo</td>
          </tr>
          <tr> 
            <td width="20%" class="tdtexttablebold" valign="middle">Vigencia</td>
            <td width="35%" class="tdpadleft5"   valign="middle"><input class="field" id="txtPromocionInicio" type="text" maxLength="12" size="12" name="txtPromocionInicio"> 
              <a href="javascript:cal1.popup()"><IMG height="15" src="images/imgCalendarIcon.gif" width="16" align="absMiddle" border="0"></a> 
              &nbsp;&nbsp; <input class="field" id="txtPromocionFin" type="text" maxLength="12" size="12" name="txtPromocionFin"> 
              <a href="javascript:cal2.popup()"><IMG height="15" src="images/imgCalendarIcon.gif" width="16" align="absMiddle" border="0"></a> 
            </td>
          </tr>
          <tr> 
            <td colspan="2"><input class="boton" id="cmdContinuar" onclick="return cmdContinuar_onclick(0)" type="button" value="Continuar" name="cmdContinuar"> 
              &nbsp; <input class="boton" id="cmdCerrar" onclick="return cmdCerrar_onclick()" type="button" value="Cerrar" name="cmdCerrar"> 
              <br></td>
          </tr>
        </table></td>
      <td width="2%"></td>
    </tr>
  </table>
  <SCRIPT language=JavaScript>
    <!-- // create calendar object(s) just after form tag closed
    var cal1 = new calendar(null, document.forms['frmPromocionesMonederoAgregar'].elements['txtPromocionInicio']);
    var cal2 = new calendar(null, document.forms['frmPromocionesMonederoAgregar'].elements['txtPromocionFin']);
    //-->
</SCRIPT>
</form>
<iframe name="ifrOculto" width="0" src="" height="0"></iframe>
</body>
</HTML>
