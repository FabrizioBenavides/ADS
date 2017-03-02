<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" enableViewState="False" Explicit="True" Trace="False" Strict="True" CodeBehind="popVentasPromocionesMonederoRelacionSucursalArchivo.aspx.vb"      Inherits="com.isocraft.backbone.ccentral.popVentasPromocionesMonederoRelacionSucursalArchivo" codePage="28592" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
<HEAD>
<title>popVentasPromocionesMonederoRelacionSucursalArchivo</title>
<%  '====================================================================
    ' Page          : popVentasPromocionesMonederoRelacionSucursalArchivo.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : 
    ' Copyright     : 2007
    ' Company       : Farmacias Benavides
    ' Author        : J.Antonio Hernandez    
    ' Last Modified : 01 de Noviembre 2007
    '====================================================================
%>

<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/Tools.js" type="text/JavaScript"></script>
<script language="JavaScript" src="../static/scripts/FuncionesString.js" type="text/JavaScript"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

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
	
    document.forms[0].elements['txtSucursalArchivo'].focus(); 	
}

function blnEntradaValida() {  
   if (document.forms[0].elements["txtSucursalArchivo"].value.length == 0) {
      alert("Por favor especifique un valor para el campo \"Archivo\".");
      document.forms[0].elements["txtSucursalArchivo"].focus();
      return(false);
   }        
   
   return (true);      
}

function objPrevioCarga_onclick() {
   if (blnEntradaValida()) {
      
       var parametrosInicio = '&intPromocionId=' + '<%=Request("intPromocionId")%>' + '&strPromocionNombre=' + '<%=Request("strPromocionNombre")%>' + '&dtmPromocionInicio=' + '<%=Request("dtmPromocionInicio")%>' + '&dtmPromocionFin=' + '<%=Request("dtmPromocionFin")%>';   
	   
       document.forms[0].action = '<%=strFormAction%>?strCmd=PrevioArchivoSucursal' + parametrosInicio; 
       document.forms[0].target="ifrOculto";
       document.forms[0].submit();
       document.forms[0].target=''; 
   }   	   
}

function fnVerPrevioCarga (intCargaArchivo, lngFolioActualCarga) {    
   if (intCargaArchivo >= 0) {
   
       document.forms[0].elements['hdnFolioActualCarga'].value = lngFolioActualCarga;
       
       url = 'popVentasPromocionesMonederoVer.aspx?strCmd=VistaPreviaSucursal&lngFolioActualCarga=' + lngFolioActualCarga;      
       var Win = window.open(url,'popPrevioArchivo','width=620,height=540,left=20,top=10,resizable=no,scrollbars=yes,menubar=no,status=no' );
   }
   else {   
      if (intCargaArchivo==-110) {
	      alert("No se pudo abrir o no existe el archivo de carga");
	  }
	  if (intCargaArchivo==-120) {
	      alert("Los registros del archivo no cumplen con la estructura (No de Sucursal).");
	  }
   }
   
}

function cmdAgregar_onclick() {
   
   if (blnEntradaValida()) {
       	   
       var parametrosInicio = 'intPromocionId=' + '<%=Request("intPromocionId")%>' + '&strPromocionNombre=' + '<%=Request("strPromocionNombre")%>' + '&dtmPromocionInicio=' + '<%=Request("dtmPromocionInicio")%>' + '&dtmPromocionFin=' + '<%=Request("dtmPromocionFin")%>';   
	   	   
       document.forms[0].action = '<%=strFormAction%>?strCmd=AgregarSucursal&' + parametrosInicio;
       document.forms[0].target="ifrOculto";
       document.forms[0].submit();
       document.forms[0].target='';      
   }
  
}

function fnUpAgregarSucursal(intActualizacion,strPromociones) {	
    if (intActualizacion > 0 ) {    
	  alert("Promoción actualizada, Total de sucursales [" + intActualizacion + "]");       
    }
    else {	    
        				
        if (intActualizacion==-120) {
	      alert("Los registros del archivo no cumplen con la estructura (No de Sucursal).");
		  return;
        }
		
        if (intActualizacion==-110) {
	      alert("No se pudo abrir o no existe el archivo de carga");
		  return;
        }
			
        if (intActualizacion==-100) {
          alert("Error en Bd no se pudo actualizar");
		  return;
		}		
	}
		    
   document.forms[0].elements['hdnFolioActualCarga'].value='';
   
   var parametrosInicio = 'intPromocionId=' + '<%=Request("intPromocionId")%>' + '&strPromocionNombre=' + '<%=Request("strPromocionNombre")%>' + '&dtmPromocionInicio=' + '<%=Request("dtmPromocionInicio")%>' + '&dtmPromocionFin=' + '<%=Request("dtmPromocionFin")%>'; 
   
   document.forms[0].action = '<%=strFormAction%>?' + parametrosInicio;
   document.forms[0].target='';  
   document.forms[0].submit();   	
}

function fnUpEliminarSucursal(intActualizacion) {

    if (intActualizacion > 0) {
    
        alert ('Se eliminaron de la promocion [' + intActualizacion + '] Sucursales');
        
        var parametrosInicio = 'intPromocionId=' + '<%=Request("intPromocionId")%>' + '&strPromocionNombre=' + '<%=Request("strPromocionNombre")%>' + '&dtmPromocionInicio=' + '<%=Request("dtmPromocionInicio")%>' + '&dtmPromocionFin=' + '<%=Request("dtmPromocionFin")%>';
         	
	    document.forms[0].action = 'popVentasPromocionesMonederoRelacionSucursalArchivo.aspx?' + parametrosInicio;
	    document.forms[0].submit(); 	    
    }
    else {
       if (intActualizacion < 0) {
            alert ('No se pudo hacer la eliminación de sucursales');
       }
    }	        
}

function doSubmit()
{
    args = doSubmit.arguments;
    var action = args[0];  
    
    var parametrosInicio = 'intPromocionId=' + '<%=Request("intPromocionId")%>' + '&strPromocionNombre=' + '<%=Request("strPromocionNombre")%>' + '&dtmPromocionInicio=' + '<%=Request("dtmPromocionInicio")%>' + '&dtmPromocionFin=' + '<%=Request("dtmPromocionFin")%>';
   
	if (action == "AgregarSucursal") 	{
        document.forms[0].target="ifrOculto";
	}
	
	if (action == "EliminarSucursal")
	{	
		if  (!confirm ('Esta seguro de eliminar la sucursal de la promoción?') )  {
			return;
		}
		else {
             document.forms[0].target="ifrOculto";
		}
	}
	
	var params = ""
	for (i=1; i < (args.length-1); i +=2)
	{
		params+= "&" + args[i] + "=" + args[i+1]
	}
		
	document.forms[0].action = 'popVentasPromocionesMonederoRelacionSucursalArchivo.aspx?strCmd=' + action + '&' + parametrosInicio + params;
	document.forms[0].submit(); 
	document.forms[0].target='';
	
}

function cmdCerrar_onclick() {	
    opener.document.forms[0].elements['cmdEjecutar'].onclick();
	window.close();	
	return(true);
}

//-->
			</script>
</HEAD>
<body language="javascript" leftMargin="0" topMargin="0" onload="return window_onload()">
<form name="frmMonederoRelacionSucursal" method="post" encType="multipart/form-data" runat="server">
  <table height="158" cellSpacing="0" cellPadding="0" width="700" border="0">
    <tr> 
      <td width="2%">&nbsp;</td>
      <td width="96%"> <table width="100%" align="center">
          <tr> 
            <td class="tdlogopop" height="21"> <img height="54" src="../static/images/logo_pop.gif" width="177"></td>
          </tr>
          <tr> 
            <td width="100%" valign="top" height="30"><h1>Relación Sucursal Promoción 
                Monedero </h1>
              <p> En esta parte se importa un archivo de sucursales a la promoción 
                seleccionada.</p></td>
          </tr>
        </table>
        <table width="100%" class="tdEnvolventeTablaAzul" cellspacing="0" cellpadding="0" border="0">
          <tr> 
            <td width="10%" class="tdtexttablebold" valign="middle">Promoción:</td>
            <td width="90%" class="tdtextablaBoldAzul" valign="middle"><%= Request("intPromocionId") %> 
              - <%= Request("strPromocionNombre") %> </td>
          </tr>
          <tr> 
            <td width="10%" class="tdtexttablebold" valign="middle">Vigencia:</td>
            <td width="90%" class="tdtextablaBoldAzul" valign="middle"><%= Request("dtmPromocionInicio") %> 
              al <%= Request("dtmPromocionFin") %> </td>
          </tr>
        </table>
        <br> <table width="100%" class="tdEnvolventeTablaGris" cellSpacing="0" cellPadding="0" border="0">
          <tr> 
            <td width="10%" class="tdtexttablebold">Archivo:</td>
            <td width="60%" class="tdtexttablebold"> <input language="javascript" class="tdcontentableblue" id="txtSucursalArchivo" title="Archivo"
										type="file" size="40" name="txtSucursalArchivo"
										runat="server"> &nbsp; <a id="objPrevioCarga" onclick="objPrevioCarga_onclick()"> 
              <IMG height="17" src="../static/images/imgNRPrevio.gif" width="17" align="absMiddle"
											border="0"></a> </td>
            <td align="center" width="30%"> <input class="button" id="cmdAgregar" name="cmdAgregar" value="Agregar" onclick="return cmdAgregar_onclick()"
										type="button"> </td>
          </tr>
        </table>
        <table width="100%">
          <tr> 
            <td><input class="boton" id="cmdCerrar" onclick="return cmdCerrar_onclick()" type="button"
										value="Cerrar" name="cmdCerrar"> </td>
          </tr>
          <tr> 
            <td> <br> <span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">Sucursales 
              Incluidas</span> <%= strConsultarSucursales %> </td>
          </tr>
          <tr> 
            <td><input type="hidden" name="hdnFolioActualCarga"  value='<%=Request("hdnFolioActualCarga")%>'></td>
          </tr>
        </table></td>
      <td width="2%">&nbsp;</td>
    </tr>
  </table>
</form>
<iframe name="ifrOculto" src="" width="0" height="0"></iframe>
</body>
</HTML>
