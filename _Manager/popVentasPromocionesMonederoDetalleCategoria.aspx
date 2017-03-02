<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" enableViewState="False" Explicit="True" Trace="False" Strict="True" CodeBehind="popVentasPromocionesMonederoDetalleCategoria.aspx.vb"      Inherits="com.isocraft.backbone.ccentral.popVentasPromocionesMonederoDetalleCategoria" codePage="28592" %>
<HTML>
<HEAD>
<title>popVentasPromocionesMonederoDetalleArticulo</title>
<%  '====================================================================
    ' Page          : popVentasPromocionesMonederoDetalleCategoria.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : 
    ' Copyright     : 2007
    ' Company       : Farmacias Benavides
    ' Author        : J.Antonio Hernandez    
    ' Last Modified : 01 de Noviembre 2007
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link href="css/estilo.css" type="text/css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/Tools.js" type="text/JavaScript"></script>
<script language="JavaScript" src="../static/scripts/FuncionesString.js" type="text/JavaScript"></script>
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
	
	<%= LlenarControlDivisionArticulos() %>
	<%= LlenarControlCategoriaArticulos() %>
	
	return(true);
}

function isEnterKey(evt) {
  if (!evt) { 
    evt = window.event
  } else if (!evt.keyCode) {
    evt.keyCode = evt.which
  }
  
  return (evt.keyCode == 13)
}

function cboDivisionArticulos_onchange() {
    document.forms[0].elements["cboCategoriaArticulos"].selectedIndex = 0;
	document.forms[0].action = "<%= strFormAction %>" + "?intPromocionId=" + <%= Request("intPromocionId") %> + "&strPromocionNombre=" + "<%= Request("strPromocionNombre") %>" + "&dtmPromocionInicio=" + "<%= Request("dtmPromocionInicio") %>" +  "&dtmPromocionFin=" + "<%= Request("dtmPromocionFin") %>" ; 
	document.forms[0].target='';  
    document.forms[0].submit();
}

function cmdCerrar_onclick() {	
    opener.document.forms[0].elements['cmdEjecutar'].onclick();
	window.close();	
	return(true);
}

function cmdLimpiar_onclick() {
   var parametrosInicio = '?intPromocionId=' + '<%=Request("intPromocionId")%>' + '&strPromocionNombre=' + '<%=Request("strPromocionNombre")%>' + '&dtmPromocionInicio=' + '<%=Request("dtmPromocionInicio")%>' + '&dtmPromocionFin=' + '<%=Request("dtmPromocionFin")%>'; 
   document.forms[0].action = '<%=strFormAction%>' + parametrosInicio;
   document.forms[0].target='';  
   document.forms[0].submit();
}

function cmdAgregar_onclick(blnActualizaPromocion) {
   var blnValidar = true;
   
   if ( document.forms[0].elements["cboDivisionArticulos"].selectedIndex == 0 ) { 
       blnValidar = false;
       alert("Seleccionar la división");
	   return;
   }
   
   if ( blnValidar && document.forms[0].elements["cboCategoriaArticulos"].selectedIndex == 0) {
       blnValidar = false;
       alert("Seleccionar la categoría");
	   return;
   }
   
   var formato=/^[0-9]{1,2}$/;
   if( !(formato.test(document.forms[0].elements["dblPorcentaje"].value)) )
   {
                alert("     El porcentaje debe ser Numérico 5-99     ");
                document.forms[0].elements["dblPorcentaje"].value = "";
                document.forms[0].elements["dblPorcentaje"].focus();
                return;
   }
   
   if(blnValidar) {
   
       var parametrosInicio = '&intPromocionId=' + '<%=Request("intPromocionId")%>' + '&strPromocionNombre=' + '<%=Request("strPromocionNombre")%>' + '&dtmPromocionInicio=' + '<%=Request("dtmPromocionInicio")%>' + '&dtmPromocionFin=' + '<%=Request("dtmPromocionFin")%>';   	   
       document.forms[0].action= '<%=strFormAction%>?strCmd=AgregarCategoria&&blnActualizaPromocion=' + blnActualizaPromocion + parametrosInicio;
	   document.forms[0].target="ifrOculto";
       document.forms[0].submit();      
   }	

}

function fnUpAgregarCategoria(intActualizacion,strPromociones) {	
    if (intActualizacion > 0 ) {    
	  alert("Promoción actualizada, Total de categorias [" + intActualizacion + "]");       
    }
    else {
	    
		if (intActualizacion==-99) {
           strErrores = 'Confirmar actualización ya que el articulo(s) existe(n) en las promociones:\n' + strPromociones;
		   
		   if (confirm (strErrores) )  {
               cmdAgregar_onclick(1);
		   }
		   		   
		   return;
		}
					
        if (intActualizacion==-100) {
          alert("Error en Bd no se pudo actualizar");
		  return;
		}		
	}
	
    document.forms[0].elements['dblPorcentaje'].value='';   
	   
    cmdLimpiar_onclick();
       	
}

function fnUpEliminarCategoria(intActualizacion) {
   cmdLimpiar_onclick();
}

function doSubmit()
{
    args = doSubmit.arguments;
    var action = args[0];
	
	if (action == "EliminarCategoria")
	{	
		if  (!confirm ('Esta seguro de eliminar la categoria de la promoción?') )  {
			return;
		}
		else {
             document.forms[0].target="ifrOculto";
		}
	}
	
	var params = ''
	for (i=1; i < (args.length-1); i +=2) 	{
		params+= '&' + args[i] + '=' + args[i+1]
	}
	
	var parametrosInicio = '&intPromocionId=' + '<%=Request("intPromocionId")%>' + '&strPromocionNombre=' + '<%=Request("strPromocionNombre")%>' + '&dtmPromocionInicio=' + '<%=Request("dtmPromocionInicio")%>' + '&dtmPromocionFin=' + '<%=Request("dtmPromocionFin")%>';
	
	document.forms[0].action = 'popVentasPromocionesMonederoDetalleCategoria.aspx?strCmd=' + action + parametrosInicio +  params;
	document.forms[0].submit(); 
	document.forms[0].target='';	
}

function dblPorcentaje_onkeydown(objEvent) {
 if (isEnterKey(objEvent)) {    
    document.forms[0].elements['cmdAgregar'].focus();
    return(false);
  }
}
//-->
</script>
</HEAD>
<body onload="return window_onload()" >
<form name="frmMonederoDetalleCategoria" action="about:blank" method="post">
  <table height="158" cellspacing="0" cellpadding="0" width="700"  border="0">
    <tr> 
      <td width="100%" class="tdlogopop" colspan="3" height="21"> <img height="54" src="../static/images/logo_pop.gif" width="177"></td>
    </tr>
    <tr> 
      <td width="2%">&nbsp;</td>
      <td width="96%" valign="top"  height="10">&nbsp;</td>
      <td width="2%">&nbsp;</td>
    </tr>
    <tr> 
      <td width="2%">&nbsp;</td>
      <td width="96%" valign="top" height="30" ><h1>Configurar Promoción Monedero 
          por Categoría</h1>
        <p> En esta parte se dan de alta las categorias y los porcentajes que 
          se aplicaran en la promocion.</p></td>
      <td width="2%">&nbsp;</td>
    </tr>
    <tr> 
      <td width="2%">&nbsp;</td>
      <td > <table width="100%" class="tdEnvolventeTablaAzul" cellspacing="0" cellpadding="0" border="0" >
          <tr> 
            <td width="10%" class="tdtexttablebold" valign="middle" >Promoción:</td>
            <td width="90%" class="tdtextablaBoldAzul" valign="middle" ><%= Request("intPromocionId") %> 
              - <%= Request("strPromocionNombre") %> </td>
          </tr>
          <tr> 
            <td width="10%" class="tdtexttablebold" valign="middle">Vigencia:</td>
            <td width="90%" class="tdtextablaBoldAzul" valign="middle"><%= Request("dtmPromocionInicio") %> 
              al <%= Request("dtmPromocionFin") %> </td>
          </tr>
        </table>
        <br> <table width="100%" class="tdEnvolventeTablaGris" >
          <tr> 
            <td width="10%" class="tdtexttablebold">División </td>
            <td width="60%" class="tdtexttablebold" ><select name="cboDivisionArticulos" class="field" id="cboDivisionArticulos" onChange="return cboDivisionArticulos_onchange()">
                <option value="0">&raquo; Seleccionar la división &laquo;</option>
              </select> </td>
            <td width="30%" rowspan="3" align="center"> <input name="cmdAgregar"  type="button" class="button" id="cmdGuardar"  value="Agregar" onclick="return cmdAgregar_onclick(0)"> 
              &nbsp; <input name="cmdLimpiar" type="button" class="button" id="cmdLimpiar" value="Limpiar" onclick="return cmdLimpiar_onclick()"> 
            </td>
          </tr>
          <tr> 
            <td width="10%" height="16" class="tdtexttablebold">Categoría </td>
            <td width="60%" class="tdtexttablebold"><select name="cboCategoriaArticulos" class="field" id="cboCategoriaArticulos" >
                <option value="0">&raquo; seleccionar la categor&iacute;a &laquo;</option>
              </select> </td>
          </tr>
          <tr> 
            <td width="10%" class="tdtexttablebold">Porcentaje </td>
            <td width="60%" class="tdtexttablebold" ><input class="field" id="dblPorcentaje" type="text" autocomplete="off"  maxlength="2" size="5" name="dblPorcentaje"  value='<%=Request("strPorcentaje")%>' onkeydown="return dblPorcentaje_onkeydown(event)"> 
            </td>
          </tr>
        </table>
        <table width="100%">
          <tr> 
            <td><input class="boton" id="cmdCerrar" onclick="return cmdCerrar_onclick()" type="button" value="Cerrar" name="cmdCerrar"> 
            </td>
          </tr>
          <tr> 
            <td><span class="txsubtitulo"><br>
              <IMG height="11" src="../static/images/bullet_subtitulos.gif" width="17" align="absMiddle">Detalle 
              Promoción</span><%=strConsultarDetalle%><br> </td>
          </tr>
        </table></td>
      <td width="2%">&nbsp;</td>
    </tr>
  </table>
</form>
<iframe name="ifrOculto" src="" width="0" height="0"></iframe>
</body>
</HTML>
