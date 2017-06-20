<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ControlAsistenciaAdministracionEmpleadosModificaciones.aspx.vb" Inherits="com.isocraft.backbone.ccentral.ControlAsistenciaAdministracionEmpleadosModificaciones" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons" %>
<html>
<head>
    <title>Sistema Administrador de Sucursal</title>
    <%
        '====================================================================
        ' Nombre        : SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones.aspx
        ' Title         : Detalle Consulta Tickets
        ' Description   : Página para Realizar actualizaciones  a la informacion sobre las asistencias(Vacaciones, permisos, dias de descanso, incapacidad, etc)			
        ' Author        : Jesus Miguel Gil G.		' 
        ' Last Modified : 21 de Abril de 2008
        '
        '                 25 de Febrero 2011 [JAHD]    Actualizacion por CADENA
        '====================================================================
    %>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
    <link href="../static/css/menu.css" rel="stylesheet">
    <link href="../static/css/menu2.css" rel="stylesheet">
    <link href="../static/css/estilo.css" rel="stylesheet">
    <script language="JavaScript" src="../static/scripts/menu.js"></script>
    <script language="JavaScript" src="../static/scripts/menu_items.js"></script>
    <script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
    <script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
    <script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
    <script language="JavaScript" src="../static/scripts/Tools.js"></script>
    <script language="JavaScript" src="../static/scripts/calendar1.js"></script>
    <script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
    <script language="javascript" id="clientEventHandlersJS">
<!--

    var strPaginaAyuda
    strPaginaAyuda = "<%=strThisPageName%>";

function window_onload() {
    MM_preloadImages('../static/images/bayuda_on.gif', '../static/images/bayuda_off.gif');
    document.forms[0].action = "<%=strFormAction%>";
		document.forms[0].elements['txaIncapacidadMedica'].style.visible = false

		calculadiasVacacionesdesdeLoad();
		calculadiasPermisodesdeLoad();
		calculadiasCapacitaciondesdeLoad();

		<% If Trim(strMensaje) <> "" Then%>
    alert('<%=strMensaje%>');
    <% End If%>		

    return (true);
}

function strCompaniaSucursal() {
    document.write("<%=intCompaniaId%>" + " - " + "<%=intSucursalId%>");
    return (true);
}

function strSucursalNombre() {
    document.write("&nbsp;" + "<%=strSucursalNombre%>");
    return (true);
}
function strDiadeDescanso() {
    document.write("&nbsp;" + "<%=strDiadeDescanso%>");
    return (true);
}
function strBajaTemporal() {
    document.write("&nbsp;" + "<%=strBajaTemporal%>");
    return (true);
}

function strNombreDeEmpleado() {
    document.write("&nbsp;" + "<%=strNombreDeEmpleado%>");
    return (true);
}



function strllenarComboEmpleados() {
    var intEmpId =<%=Convert.ToDouble(Request.QueryString("intEmpleadoId"))%>
	document.write("&nbsp;" + "<%=strllenarComboEmpleados%>");
    document.forms[0].elements["cboEmpleados"].value = intEmpId;
    //hdnElegido
    return (true);
}

function cboEmpleados_onchange() {
    //var i=document.forms[0].elements['cboEmpleados'].selectedIndex-1;
    //document.forms[0].elements['hdnElegido'].value=document.forms[0].elements['hdnElegido'+i].value
    var intEmpId = document.forms[0].elements["cboEmpleados"].value
    document.location.href = "SucursalEmpleadosControlAsistenciaAdministracionEmpleadosModificaciones.aspx?intEmpleadoId=" + intEmpId;
}

function strObservacionesIncapacidad() {
    document.write("&nbsp;" + "<%=strObservacionesIncapacidad%>");
    return (true);
}
function strObservacionesPermiso() {
    document.write("&nbsp;" + "<%=strObservacionesPermiso%>");
    return (true);
}
function strDiasDisponiblesVacaciones() {
    document.write("&nbsp;" + "<%=strDiasDisponiblesVacaciones%>");
    return (true);
}

function strPermisoEspecialFechaInicio() {
    document.write("&nbsp;" + "<%=strPermisoEspecialFechaInicio%>");
    return (true);
}

function strPermisoEspecialFechaFin() {
    document.write("&nbsp;" + "<%=strPermisoEspecialFechaFin%>");
    return (true);
}

function strPermisoEspecialConSueldo() {
    document.write("&nbsp;" + "<%=strPermisoEspecialConSueldo%>");
    return (true);
}

function strIncapacidadMedicaFechaInicio() {
    document.write("&nbsp;" + "<%=strIncapacidadMedicaFechaInicio%>");
    return (true);
}
function strIncapacidadMedicaFechaFin() {
    document.write("&nbsp;" + "<%=strIncapacidadMedicaFechaFin%>");
    return (true);
}

function strIncapacidadMedicaFolio() {
    document.write("&nbsp;" + "<%=strIncapacidadMedicaFolio%>");
    return (true);
}

function strIncapacidadMedicaMotivos() {
    document.write("&nbsp;" + "<%=strIncapacidadMedicaMotivos%>");
    return (true);
}

function strCapacitacionFechaInicio() {
    document.write("&nbsp;" + "<%=strCapacitacionFechaInicio%>");
        return (true);
    }

    function strCapacitacionFechaFin() {
        document.write("&nbsp;" + "<%=strCapacitacionFechaFin%>");
        return (true);
    }

    function strObtenerObservacionesCapacitacion() {
        //document.write("&nbsp;"+"<TEXTAREA id='txtCapacitacion' rows='3' cols='35' name='txtCapacitacion'> </TEXTAREA>");
        document.write("&nbsp;" + "<%=strObtenerObservacionesCapacitacion%>");
        return (true);
    }

    function strCamposHidden() {
        document.write("&nbsp;" + "<%=strCamposHidden%>");
    return (true);
}

function strVacacionesFechaInicio() {
    document.write("&nbsp;" + "<%=strVacacionesFechaInicio%>");
    return (true);
}
function strVacacionesFechaFin() {
    document.write("&nbsp;" + "<%=strVacacionesFechaFin%>");

    return (true);
}

function cambioIncapacidadFechaInicio() {
    var fIni = document.forms[0].elements["txtIncapacidadMedicaInicio"].value

    if (fIni != "") {
        if (blnValidarCampo(document.forms('SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones').elements('txtIncapacidadMedicaInicio'), false, 'IncapacidadMedica Fecha inicio', cintTipoCampoFecha, 10, 10, '')) {
            var fFin = document.forms[0].elements["txtIncapacidadMedicaFinal"].value
            if (fFin != "") {
                if (fIni > fFin) {
                    alert("La fecha de inicio de incapacidad médica no puede ser mayor a la fecha final de incapacidad médica");
                    document.forms[0].elements["txtIncapacidadMedicaInicio"].value = "";
                    document.forms[0].elements["txtIncapacidadMedicaInicio"].focus();
                }
            }
        }
    }
}

function cambioIncapacidadFechaFin() {
    var fIni = document.forms[0].elements["txtIncapacidadMedicaInicio"].value
    var fFin = document.forms[0].elements["txtIncapacidadMedicaFinal"].value
    if (fFin != "") {
        if (fIni != "") {
            if ((blnValidarCampo(document.forms('SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones').elements('txtIncapacidadMedicaInicio'), false, 'IncapacidadMedica Fecha inicio', cintTipoCampoFecha, 10, 10, '')) && (blnValidarCampo(document.forms('SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones').elements('txtIncapacidadMedicaFinal'), false, 'IncapacidadMedica Fecha Final', cintTipoCampoFecha, 10, 10, ''))) {
                var strDia = fIni.substring(0, 2);
                var strMes = fIni.substring(3, 5);
                var strAno = fIni.substring(6, 10);

                var fIni = new Date(strMes + "/" + strDia + "/" + strAno);

                var strDia = fFin.substring(0, 2);
                var strMes = fFin.substring(3, 5);
                var strAno = fFin.substring(6, 10);

                var fFin = new Date(strMes + "/" + strDia + "/" + strAno);

                var fechaActual = new Date();
                var diasEntreFechas = eval(((((fFin - fechaActual) / 60) / 60) / 24) / 1000) + 1;

                if (diasEntreFechas <= 0) {
                    alert("La fecha de fin de incapacidad médica no puede ser menor a la actual ");
                    document.forms[0].elements["txtIncapacidadMedicaFinal"].focus();
                    document.forms[0].elements["txtIncapacidadMedicaFinal"].value = "";
                    return false;
                }

                if (fIni > fFin) {
                    alert("La fecha de inicio de incapacidad médica no puede ser mayor a la fecha final de incapacidad médica");
                    document.forms[0].elements["txtIncapacidadMedicaInicio"].focus();
                    document.forms[0].elements["txtIncapacidadMedicaInicio"].value = "";
                }
            }
        }
    }
}

function cambioPermisoEspecialFechaInicio() {
    var fIni = document.forms[0].elements["txtPermisoEspecialInicio"].value;

    if (fIni != "") {
        if ((blnValidarCampo(document.forms('SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones').elements('txtPermisoEspecialInicio'), false, 'Permiso Especial Fecha de Inicio', cintTipoCampoFecha, 10, 10, '')) && (blnValidarCampo(document.forms('SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones').elements('txtPermisoEspecialFin'), false, 'Permiso Especial Fecha de Fin', cintTipoCampoFecha, 10, 10, ''))) {
            var fFin = document.forms[0].elements["txtPermisoEspecialFin"].value;
            if (fFin != "") {
                if (fIni > fFin) {
                    alert("La fecha de inicio de permiso especial no puede ser mayor a la fecha final");
                    document.forms[0].elements["txtPermisoEspecialInicio"].value = "";
                    document.forms[0].elements["txtPermisoEspecialInicio"].focus();
                    return false
                }
            }
            var lblDias = document.getElementById("lblDiasPermiso");
            lblDias.innerHTML = "0";
            var strDia = fIni.substring(0, 2);
            var strMes = fIni.substring(3, 5);
            var strAno = fIni.substring(6, 10);

            var fIni = new Date(strMes + "/" + strDia + "/" + strAno);

            var strDia = fFin.substring(0, 2);
            var strMes = fFin.substring(3, 5);
            var strAno = fFin.substring(6, 10);

            var fFin = new Date(strMes + "/" + strDia + "/" + strAno);

            var diaDescanso = document.forms[0].elements["cmdDiaDescanso"].value // se obtiene el dia de descanso de lo que diga el combo dia de descanso
            var parrafo = document.getElementById("lblDiasPermiso");
            parrafo.innerHTML = 0;

            var diasEntreFechas = eval(((((fFin - fIni) / 60) / 60) / 24) / 1000) + 1;//segundos,minutos,horas...
            var diaSemana = 0
            var UnDiaEnMiliSegundos = parseInt(1 * 24 * 60 * 60 * 1000);//milisegundos de un dia										
            var diafIni = 0
            var contDiasDescanso = 0;

            for (var i = 0; i < diasEntreFechas; i++) {
                diaSemana = 1 + fIni.getDay();
                if (diaSemana == diaDescanso)
                    contDiasDescanso++;
                fIni.setTime(parseInt(fIni.getTime() + UnDiaEnMiliSegundos));
            }
            var dias = 0;
            dias = Math.floor(diasEntreFechas - contDiasDescanso);
            if (dias > 0)
                lblDias.innerHTML = dias;
            else
                lblDias.innerHTML = 0;


        }
        else {
            document.forms[0].elements["txtPermisoEspecialInicio"].value = "";
            document.forms[0].elements["txtPermisoEspecialInicio"].focus();
        }
    }
}

function cambioPermisoEspecialFechaFin() {
    if ((document.forms[0].elements["txtPermisoEspecialInicio"].value != "") && (document.forms[0].elements["txtPermisoEspecialFin"].value != "")) {
        var fIni = document.forms[0].elements["txtPermisoEspecialInicio"].value;
        var fFin = document.forms[0].elements["txtPermisoEspecialFin"].value;
        var lblDias = document.getElementById("lblDiasPermiso");
        lblDias.innerHTML = 0;

        var strDia = fIni.substring(0, 2);
        var strMes = fIni.substring(3, 5);
        var strAno = fIni.substring(6, 10);

        var fIni = new Date(strMes + "/" + strDia + "/" + strAno);

        var strDia = fFin.substring(0, 2);
        var strMes = fFin.substring(3, 5);
        var strAno = fFin.substring(6, 10);

        var fFin = new Date(strMes + "/" + strDia + "/" + strAno);

        var fechaActual = new Date();
        var diasEntreFechas = eval(((((fFin - fechaActual) / 60) / 60) / 24) / 1000) + 1;


        if (diasEntreFechas <= 0) {
            alert("Las fecha de fin de permiso especial no puede ser menor a la fecha actual ");
            document.forms[0].elements["txtPermisoEspecialFin"].value = "";
            document.forms[0].elements["txtPermisoEspecialFin"].focus();
            return false;
        }

        //  diaDescanso="<%=ConsultaArray(1)%>";					  	
	    var diaDescanso = document.forms[0].elements["cmdDiaDescanso"].value // se obtiene el dia de descanso de lo que diga el combo dia de descanso

	    var i = 0;

	    //validar si las fechas son validas
	    if ((blnValidarCampo(document.forms('SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones').elements('txtPermisoEspecialInicio'), false, 'Permiso Especial Fecha Inicio', cintTipoCampoFecha, 10, 10, '')) && (blnValidarCampo(document.forms('SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones').elements('txtPermisoEspecialFin'), false, 'Permiso Especial Fecha Fin', cintTipoCampoFecha, 10, 10, ''))) {
	        if (fIni != "") {
	            if (fIni <= fFin) {
	                //dias a descontar por ser dias de descanso
	                var diaSemana = 0
	                var UnDiaEnMiliSegundos = parseInt(1 * 24 * 60 * 60 * 1000);//milisegundos de un dia										
	                var diafIni = 0
	                var contDiasDescanso = 0;
	                diasEntreFechas = eval(((((fFin - fIni) / 60) / 60) / 24) / 1000) + 1
	                for (var i = 0; i < diasEntreFechas; i++) {
	                    diaSemana = 1 + fIni.getDay();
	                    if (diaSemana == diaDescanso)
	                        contDiasDescanso++;
	                    fIni.setTime(parseInt(fIni.getTime() + UnDiaEnMiliSegundos));
	                }
	                fIni = document.forms[0].elements["txtPermisoEspecialInicio"].value;
	                strDia = fIni.substring(0, 2);
	                strMes = fIni.substring(3, 5);
	                strAno = fIni.substring(6, 10);
	                fIni = new Date(strMes + "/" + strDia + "/" + strAno);

	                //Actualizando pantalla					
	                var dias = Math.floor(diasEntreFechas - contDiasDescanso);

	                if (dias > 0)
	                    lblDias.innerHTML = dias;
	                else
	                    lblDias.innerHTML = 0;


	            }
	            else {
	                alert("La fecha final de vacaciones no puede ser menor a la fecha inicial");
	                document.forms[0].elements["txtVacacionesFin"].value = "";
	                document.forms[0].elements["txtVacacionesFin"].focus();
	            }
	        }

	    }
	}
}

function cambioVacacionesFechaInicio() {

    if ((document.forms[0].elements["txtVacacionesInicio"].value != "") && (document.forms[0].elements["txtVacacionesFin"].value != "")) {
        var fIni = document.forms[0].elements["txtVacacionesInicio"].value
        var fFin = document.forms[0].elements["txtVacacionesFin"].value

        var strDia = fIni.substring(0, 2);
        var strMes = fIni.substring(3, 5);
        var strAno = fIni.substring(6, 10);

        var fIni = new Date(strMes + "/" + strDia + "/" + strAno);

        var strDia = fFin.substring(0, 2);
        var strMes = fFin.substring(3, 5);
        var strAno = fFin.substring(6, 10);

        var fFin = new Date(strMes + "/" + strDia + "/" + strAno);


        var diaDescanso = document.forms[0].elements["cmdDiaDescanso"].value // se obtiene el dia de descanso de lo que diga el combo dia de descanso

        var diaFestivoArray = new Array();
        var diaFestivo = "<%=ConsultarDiasFestivos()%>";

			var i = 0;
			var fecha = new Array();
			var parrafo = document.getElementById("lblDias");
     //parrafo.innerHTML=0;								
			var posComas = 0;
			var contador = 0;
			var ini = 0;
			var posComasV = new Array;

			for (var iCont = 0 ; iCont < diaFestivo.length ; iCont++) {
			    if (diaFestivo.charAt(iCont) == ",") {
			        posComasV[contador] = iCont;
			        contador++;
			    }
			}

			for (var x = 0; x < posComasV.length; x++) {
			    fecha[x] = diaFestivo.substring(ini, posComasV[x]);
			    ini = posComasV[x] + 1;
			}

     //validar si las fechas son validas
			if ((blnValidarCampo(document.forms('SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones').elements('txtVacacionesInicio'), false, 'txtVacacionesInicio', cintTipoCampoFecha, 10, 10, '')) && (blnValidarCampo(document.forms('SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones').elements('txtVacacionesFin'), false, 'txtVacacionesFin', cintTipoCampoFecha, 10, 10, ''))) {
			    if (fFin != "") {
			        if (fIni <= fFin) {
			            fFestivas = new Array();
			            for (var i = 0; i < fecha.length; i++) {
			                fFestivas[i] = fecha[i];
			            }
			            var fdbIni = new Date(fFestivas[0]);
			            var contDiasFestivos = 0;//contiene el numero de dias festivos que se encuentran en un rango de fechas						
			            var diaFestivo;


			            var diasEntreFechas = eval(((((fFin - fIni) / 60) / 60) / 24) / 1000) + 1;//segundos,minutos,horas...

			            if (fFin > fdbIni) {
			                var diaSemanaFechaFestiva = 0;
			                for (var i = 0; i < fFestivas.length; i++) {
			                    diaFestivo = new Date(fFestivas[i]);
			                    diaSemanaFechaFestiva = 1 + diaFestivo.getDay();
			                    if ((fFin >= diaFestivo) && (fIni <= diaFestivo))
			                        if (diaSemanaFechaFestiva != diaDescanso)//si dia descanso = dia festivo solo se restará el dia para el dia de descanso y no ambos
			                            contDiasFestivos++;
			                }
			            }
			            //dias a descontar por ser dias de descanso
			            var diaSemana = 0
			            var UnDiaEnMiliSegundos = parseInt(1 * 24 * 60 * 60 * 1000);//milisegundos de un dia										
			            var diafIni = 0
			            var contDiasDescanso = 0;

			            for (var i = 0; i < diasEntreFechas; i++) {
			                diaSemana = 1 + fIni.getDay();
			                if (diaSemana == diaDescanso)
			                    contDiasDescanso++;
			                fIni.setTime(parseInt(fIni.getTime() + UnDiaEnMiliSegundos));
			            }

			            //Actualizando pantalla
			            var lblDias = document.getElementById("lblDias");
			            var dias = Math.floor(diasEntreFechas - contDiasDescanso - contDiasFestivos);
			            var diasDisponibles = "<%=ConsultaArray(0)%>";
					if (diasDisponibles >= dias && dias >= 0)
					    lblDias.innerHTML = dias;
					else {
					    alert("El número de días ha excedido a los disponibles");
					    lblDias.innerHTML = 0;
					    document.forms[0].elements["txtVacacionesInicio"].value = "";
					    document.forms[0].elements["txtVacacionesInicio"].focus();
					}
                }
                else {
                    alert("La fecha final de vacaciones no puede ser menor a la fecha inicial");
                    document.forms[0].elements["txtVacacionesInicio"].value = "";
                    document.forms[0].elements["txtVacacionesInicio"].focus();
                }
            }

        }
    }
}

function fnValidaDiasCapacitacion() {


}

function cambioDiaDescanso() {
    var diaDescanso = document.forms[0].elements["cmdDiaDescanso"].value; // se obtiene el dia de descanso de lo que diga el combo dia de descanso


    var strGrupo = "<%= strGrupoDescripcion()%>";
     if ((strGrupo == 'ADMINISTRATIVO') && (diaDescanso != '1')) {

         document.forms[0].elements["cmdDiaDescanso"].value = '1';
         alert('El dia de descanso para el empleado administrativo es el domingo, no lo puede cambiar.');
         return (false);
     }


     document.forms[0].elements["hdnDiaDescanso"].value = diaDescanso;

     if ((document.forms[0].elements["txtVacacionesInicio"].value != "") && (document.forms[0].elements["txtVacacionesFin"].value != "")) {
         var fIni = document.forms[0].elements["txtVacacionesInicio"].value
         var fFin = document.forms[0].elements["txtVacacionesFin"].value

         var strDia = fIni.substring(0, 2);
         var strMes = fIni.substring(3, 5);
         var strAno = fIni.substring(6, 10);

         var fIni = new Date(strMes + "/" + strDia + "/" + strAno);

         var strDia = fFin.substring(0, 2);
         var strMes = fFin.substring(3, 5);
         var strAno = fFin.substring(6, 10);

         var fFin = new Date(strMes + "/" + strDia + "/" + strAno);


         var diaFestivoArray = new Array();
         var diaFestivo = "<%=ConsultarDiasFestivos()%>";

			var i = 0;
			var fecha = new Array();
			var parrafo = document.getElementById("lblDias");
			parrafo.innerHTML = 0;
			var posComas = 0;
			var contador = 0;
			var ini = 0;
			var posComasV = new Array;

			for (var iCont = 0 ; iCont < diaFestivo.length ; iCont++) {
			    if (diaFestivo.charAt(iCont) == ",") {
			        posComasV[contador] = iCont;
			        contador++;
			    }
			}

			for (var x = 0; x < posComasV.length; x++) {
			    fecha[x] = diaFestivo.substring(ini, posComasV[x]);
			    ini = posComasV[x] + 1;
			}

         //validar si las fechas son validas
			if ((blnValidarCampo(document.forms('SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones').elements('txtVacacionesInicio'), false, 'txtVacacionesInicio', cintTipoCampoFecha, 10, 10, '')) && (blnValidarCampo(document.forms('SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones').elements('txtVacacionesFin'), false, 'txtVacacionesFin', cintTipoCampoFecha, 10, 10, ''))) {
			    if (fIni <= fFin) {

			        fFestivas = new Array();
			        for (var i = 0; i < fecha.length; i++) {
			            fFestivas[i] = fecha[i];

			        }
			        var fdbIni = new Date(fFestivas[0]);
			        var contDiasFestivos = 0;//contiene el numero de dias festivos implecitos en un rango de fechas						
			        var diaFestivo;
			        var diasEntreFechas = eval(((((fFin - fIni) / 60) / 60) / 24) / 1000) + 1;//segundos,minutos,horas...

			        if (fFin >= fdbIni) {
			            var diaSemanaFechaFestiva = 0;
			            for (var i = 0; i < fFestivas.length; i++) {
			                diaFestivo = new Date(fFestivas[i]);
			                diaSemanaFechaFestiva = 1 + diaFestivo.getDay();

			                if ((fFin >= diaFestivo) && (fIni <= diaFestivo))
			                    if (diaSemanaFechaFestiva != diaDescanso)//si dia descanso = dia festivo solo se restará el dia para el dia de descanso y no ambos
			                        contDiasFestivos++;
			            }
			        }
			        //dias a descontar por ser dias de descanso
			        var diaSemana = 0
			        var UnDiaEnMiliSegundos = parseInt(1 * 24 * 60 * 60 * 1000);//milisegundos de un dia										
			        var diafIni = 0
			        var contDiasDescanso = 0;

			        for (var i = 0; i < diasEntreFechas; i++) {
			            diaSemana = 1 + fIni.getDay();
			            if (diaSemana == diaDescanso)
			                contDiasDescanso++;
			            fIni.setTime(parseInt(fIni.getTime() + UnDiaEnMiliSegundos));
			        }

			        //Actualizando pantalla
			        var dias = Math.floor(diasEntreFechas - contDiasDescanso - contDiasFestivos);
			        var diasDisponibles = "<%=ConsultaArray(0)%>";
					if (diasDisponibles >= dias && dias >= 0)
					    parrafo.innerHTML = dias;
					else {
					    alert("El número de días ha excedido a los disponibles");
					    parrafo.innerHTML = 0;
					    document.forms[0].elements["txtVacacionesFin"].value = "";
					    document.forms[0].elements["txtVacacionesFin"].focus();
					}
                }
                else {
                    alert("La fecha final de vacaciones no puede ser menor a la fecha inicial");
                    document.forms[0].elements["txtVacacionesFin"].value = "";
                    document.forms[0].elements["txtVacacionesFin"].focus();
                }
            }
        }
     //***********************Fin validacion vacaciones

        if (document.forms[0].elements["txtPermisoEspecialFin"].value != "" && document.forms[0].elements["txtPermisoEspecialInicio"].value != "") {

            var fIniPermiso = document.forms[0].elements["txtPermisoEspecialInicio"].value
            var fFinPermiso = document.forms[0].elements["txtPermisoEspecialFin"].value

            var strDiaP = fIniPermiso.substring(0, 2);
            var strMesP = fIniPermiso.substring(3, 5);
            var strAnoP = fIniPermiso.substring(6, 10);

            var fIniPermiso = new Date(strMesP + "/" + strDiaP + "/" + strAnoP);

            strDia = fFinPermiso.substring(0, 2);
            strMes = fFinPermiso.substring(3, 5);
            strAno = fFinPermiso.substring(6, 10);

            var fFinPermiso = new Date(strMes + "/" + strDia + "/" + strAno);

            var diaDescanso = document.forms[0].elements["cmdDiaDescanso"].value // se obtiene el dia de descanso de lo que diga el combo dia de descanso

            var diasEntreFechas = eval(((((fFinPermiso - fIniPermiso) / 60) / 60) / 24) / 1000) + 1;//segundos,minutos,horas...

            var contDiasDescanso = 0;

            for (var i = 0; i < diasEntreFechas; i++) {
                diaSemana = 1 + fIniPermiso.getDay();
                if (diaSemana == diaDescanso)
                    contDiasDescanso++;
                fIniPermiso.setTime(parseInt(fIniPermiso.getTime() + UnDiaEnMiliSegundos));
            }

            //Actualizando pantalla
            var diasPermiso = document.getElementById("lblDiasPermiso");
            diasPermiso.innerHTML = 0;
            var dias = Math.floor(diasEntreFechas - contDiasDescanso);
            if (dias > 0)
                diasPermiso.innerHTML = dias;
            else
                diasPermiso.innerHTML = 0;
        }

    }

    function cambioVacacionesFin() {

        if ((document.forms[0].elements["txtVacacionesInicio"].value != "") && (document.forms[0].elements["txtVacacionesFin"].value != "")) {

            var fIni = document.forms[0].elements["txtVacacionesInicio"].value
            var fFin = document.forms[0].elements["txtVacacionesFin"].value

            var strDia = fIni.substring(0, 2);
            var strMes = fIni.substring(3, 5);
            var strAno = fIni.substring(6, 10);

            var fIni = new Date(strMes + "/" + strDia + "/" + strAno);

            var strDia = fFin.substring(0, 2);
            var strMes = fFin.substring(3, 5);
            var strAno = fFin.substring(6, 10);

            var fFin = new Date(strMes + "/" + strDia + "/" + strAno);

            var fechaActual = new Date();
            var diasEntreFechas = eval(((((fFin - fechaActual) / 60) / 60) / 24) / 1000) + 1;

            if (diasEntreFechas <= 0) {
                alert("La fecha de fin de vacaciones no puede ser menor a la actual ");
                document.forms[0].elements["txtVacacionesFin"].focus();
                document.forms[0].elements["txtVacacionesFin"].value = "";
                return false;

            }

            //  diaDescanso="<%=ConsultaArray(1)%>";				
	    var diaDescanso = document.forms[0].elements["cmdDiaDescanso"].value // se obtiene el dia de descanso de lo que diga el combo dia de descanso

	    var diaFestivoArray = new Array();
	    var diaFestivo = "<%=ConsultarDiasFestivos()%>";

			var i = 0;
			var fecha = new Array();
			var parrafo = document.getElementById("lblDias");
			parrafo.innerHTML = 0;
			var posComas = 0;
			var contador = 0;
			var ini = 0;
			var posComasV = new Array;

			for (var iCont = 0 ; iCont < diaFestivo.length ; iCont++) {
			    if (diaFestivo.charAt(iCont) == ",") {
			        posComasV[contador] = iCont;
			        contador++;
			    }
			}

			for (var x = 0; x < posComasV.length; x++) {
			    fecha[x] = diaFestivo.substring(ini, posComasV[x]);
			    ini = posComasV[x] + 1;
			}

	    //validar si las fechas son validas
			if ((blnValidarCampo(document.forms('SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones').elements('txtVacacionesInicio'), false, 'txtVacacionesInicio', cintTipoCampoFecha, 10, 10, '')) && (blnValidarCampo(document.forms('SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones').elements('txtVacacionesFin'), false, 'txtVacacionesFin', cintTipoCampoFecha, 10, 10, ''))) {
			    if (fIni != "") {
			        if (fIni <= fFin) {
			            fFestivas = new Array();
			            for (var i = 0; i < fecha.length; i++) {
			                fFestivas[i] = fecha[i];
			            }
			            var fdbIni = new Date(fFestivas[0]);
			            var contDiasFestivos = 0;//contiene el numero de dias festivos implecitos en un rango de fechas						
			            var diaFestivo;
			            var diasEntreFechas = eval(((((fFin - fIni) / 60) / 60) / 24) / 1000) + 1;//segundos,minutos,horas...

			            if (fFin > fdbIni) {
			                var diaSemanaFechaFestiva = 0;
			                for (var i = 0; i < fFestivas.length; i++) {
			                    diaFestivo = new Date(fFestivas[i]);
			                    diaSemanaFechaFestiva = 1 + diaFestivo.getDay();

			                    if ((fFin >= diaFestivo) && (fIni <= diaFestivo))
			                        if (diaSemanaFechaFestiva != diaDescanso)//si dia descanso = dia festivo solo se restará el dia para el dia de descanso y no ambos
			                            contDiasFestivos++;
			                }
			            }
			            //dias a descontar por ser dias de descanso
			            var diaSemana = 0
			            var UnDiaEnMiliSegundos = parseInt(1 * 24 * 60 * 60 * 1000);//milisegundos de un dia										
			            var diafIni = 0
			            var contDiasDescanso = 0;

			            for (var i = 0; i < diasEntreFechas; i++) {
			                diaSemana = 1 + fIni.getDay();
			                if (diaSemana == diaDescanso)
			                    contDiasDescanso++;
			                fIni.setTime(parseInt(fIni.getTime() + UnDiaEnMiliSegundos));
			            }
			            //Actualizando pantalla
			            var dias = Math.floor(diasEntreFechas - contDiasDescanso - contDiasFestivos);
			            var diasDisponibles = "<%=ConsultaArray(0)%>";
					if (diasDisponibles >= dias && dias >= 0)
					    parrafo.innerHTML = dias;
					else {
					    alert("El número de días ha excedido a los disponibles");
					    parrafo.innerHTML = 0;
					    document.forms[0].elements["txtVacacionesFin"].value = "";
					    document.forms[0].elements["txtVacacionesFin"].focus();
					}
                }
                else {
                    alert("La fecha final de vacaciones no puede ser menor a la fecha inicial");
                    document.forms[0].elements["txtVacacionesFin"].value = "";
                    document.forms[0].elements["txtVacacionesFin"].focus();
                }
            }

        }
    }
}

function cambioMotivos() {

    document.forms[0].elements["hdnMotivo"].value = document.forms[0].elements["cboMotivos"].value //motivo

}

function calculadiasVacacionesdesdeLoad() {
    var diaDescanso = "<%=ConsultaArray(1)%>";
    document.forms[0].elements["hdnDiaDescanso"].value = diaDescanso
    document.forms[0].elements["hdnDiaDescansoOriginal"].value = diaDescanso
    document.forms[0].elements["hdnMotivo"].value = "<%=ConsultaArray(14)%>"; //motivo
    if ((document.forms[0].elements["txtVacacionesInicio"].value != "") && (document.forms[0].elements["txtVacacionesFin"].value != "")) {
        var fIni = document.forms[0].elements["txtVacacionesInicio"].value;
        var fFin = document.forms[0].elements["txtVacacionesFin"].value;

        var strDia = fIni.substring(0, 2);
        var strMes = fIni.substring(3, 5);
        var strAno = fIni.substring(6, 10);

        var fIni = new Date(strMes + "/" + strDia + "/" + strAno);

        var strDia = fFin.substring(0, 2);
        var strMes = fFin.substring(3, 5);
        var strAno = fFin.substring(6, 10);

        var fFin = new Date(strMes + "/" + strDia + "/" + strAno);

        var diaFestivoArray = new Array();
        var diaFestivo = "<%=ConsultarDiasFestivos()%>";

			var i = 0;
			var fecha = new Array();

			var parrafo = document.getElementById("lblDias");
			parrafo.innerHTML = 0;

			var posComas = 0;
			var contador = 0;
			var ini = 0;
			var posComasV = new Array;

			for (var iCont = 0 ; iCont < diaFestivo.length ; iCont++) {
			    if (diaFestivo.charAt(iCont) == ",") {
			        posComasV[contador] = iCont;
			        contador++;
			    }
			}

			for (var x = 0; x < posComasV.length; x++) {
			    fecha[x] = diaFestivo.substring(ini, posComasV[x]);
			    ini = posComasV[x] + 1;
			}
    	    //validar si las fechas son validas
			if ((blnValidarCampo(document.forms('SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones').elements('txtVacacionesInicio'), false, 'txtVacacionesInicio', cintTipoCampoFecha, 10, 10, '')) && (blnValidarCampo(document.forms('SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones').elements('txtVacacionesFin'), false, 'txtVacacionesFin', cintTipoCampoFecha, 10, 10, ''))) {
			    var fFestivas = new Array();
			    for (var i = 0; i < fecha.length; i++) {
			        fFestivas[i] = fecha[i];
			    }
			    var fdbIni = new Date(fFestivas[0]);
			    var contDiasFestivos = 0;//contiene el numero de dias festivos implecitos en un rango de fechas						

			    var diasEntreFechas = eval(((((fFin - fIni) / 60) / 60) / 24) / 1000) + 1;//segundos,minutos,horas...				

			    if (fFin > fdbIni) {
			        var diaSemanaFechaFestiva = 0;
			        for (var i = 0; i < fFestivas.length; i++) {
			            diaFestivo = new Date(fFestivas[i]);
			            diaSemanaFechaFestiva = 1 + diaFestivo.getDay();

			            if ((fFin >= diaFestivo) && (fIni <= diaFestivo))
			                if (diaSemanaFechaFestiva != diaDescanso)//si dia descanso = dia festivo solo se restará el dia para el dia de descanso y no ambos
			                    contDiasFestivos++;
			        }
			    }

			    var diaSemana = 0
			    var UnDiaEnMiliSegundos = parseInt(1 * 24 * 60 * 60 * 1000);//milisegundos de un dia					

			    var diafIni = 0
			    var contDiasDescanso = 0;

			    for (var i = 0; i < diasEntreFechas; i++) {
			        diaSemana = 1 + fIni.getDay();
			        if (diaSemana == diaDescanso)
			            contDiasDescanso++;
			        fIni.setTime(parseInt(fIni.getTime() + UnDiaEnMiliSegundos));
			    }
			    //Actualizando pantalla

			    var dias = Math.floor(diasEntreFechas - contDiasDescanso - contDiasFestivos);

			    var diasDisponibles = "<%=ConsultaArray(0)%>";
					if (diasDisponibles >= dias && dias >= 0)
					    parrafo.innerHTML = dias;
					else {
					    alert("El número de días ha excedido a los disponibles");
					    parrafo.innerHTML = 0;
					    document.forms[0].elements["txtVacacionesFin"].value = "";
					    document.forms[0].elements["txtVacacionesFin"].focus();
					}
                }

            }
        }


        function calculadiasPermisodesdeLoad() {

            if ((document.forms[0].elements["txtPermisoEspecialInicio"].value != "") && (document.forms[0].elements["txtPermisoEspecialFin"].value != "")) {
                var fIni = document.forms[0].elements["txtPermisoEspecialInicio"].value;
                var fFin = document.forms[0].elements["txtPermisoEspecialFin"].value;

                var strDia = fIni.substring(0, 2);
                var strMes = fIni.substring(3, 5);
                var strAno = fIni.substring(6, 10);

                var fIni = new Date(strMes + "/" + strDia + "/" + strAno);

                var strDia = fFin.substring(0, 2);
                var strMes = fFin.substring(3, 5);
                var strAno = fFin.substring(6, 10);
                var fFin = new Date(strMes + "/" + strDia + "/" + strAno);

                diaDescanso = "<%=ConsultaArray(1)%>";
			var i = 0;
			var fecha = new Array();
			var parrafo = document.getElementById("lblDiasPermiso");
			parrafo.innerHTML = 0;

	    //validar si las fechas son validas
			if ((blnValidarCampo(document.forms('SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones').elements('txtPermisoEspecialInicio'), false, 'Permiso Especial Fecha de Inicio', cintTipoCampoFecha, 10, 10, '')) && (blnValidarCampo(document.forms('SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones').elements('txtPermisoEspecialFin'), false, 'Permiso especial Fecha Fin', cintTipoCampoFecha, 10, 10, ''))) {
			    var diasEntreFechas = eval(((((fFin - fIni) / 60) / 60) / 24) / 1000) + 1;//segundos,minutos,horas...				

			    var diaSemana = 0
			    var UnDiaEnMiliSegundos = parseInt(1 * 24 * 60 * 60 * 1000);//milisegundos de un dia					

			    var diafIni = 0
			    var contDiasDescanso = 0;

			    for (var i = 0; i < diasEntreFechas; i++) {
			        diaSemana = 1 + fIni.getDay();
			        if (diaSemana == diaDescanso)
			            contDiasDescanso++;
			        fIni.setTime(parseInt(fIni.getTime() + UnDiaEnMiliSegundos));
			    }
			    //Actualizando pantalla
			    var dias = Math.floor(diasEntreFechas - contDiasDescanso);
			    if (dias > 0)
			        parrafo.innerHTML = dias;
			    else
			        parrafo.innerHTML = 0;
			}
        }
    }

    //inicio de carga de vacaciones

    function calculadiasCapacitaciondesdeLoad() {

        var diaDescanso = "<%=ConsultaArray(1)%>";
        document.forms[0].elements["hdnDiaDescanso"].value = diaDescanso
        document.forms[0].elements["hdnDiaDescansoOriginal"].value = diaDescanso
        document.forms[0].elements["hdnMotivo"].value = "<%=ConsultaArray(14)%>"; //motivo

        if ((document.forms[0].elements["txtCapacitacionInicio"].value != "") && (document.forms[0].elements["txtCapacitacionFin"].value != "")) {

            var fIni = document.forms[0].elements["txtCapacitacionInicio"].value;
            var fFin = document.forms[0].elements["txtCapacitacionFin"].value;

            var strDia = fIni.substring(0, 2);
            var strMes = fIni.substring(3, 5);
            var strAno = fIni.substring(6, 10);

            var fIni = new Date(strMes + "/" + strDia + "/" + strAno);

            var strDia = fFin.substring(0, 2);
            var strMes = fFin.substring(3, 5);
            var strAno = fFin.substring(6, 10);

            var fFin = new Date(strMes + "/" + strDia + "/" + strAno);

            var diaFestivoArray = new Array();
            var diaFestivo = "<%=ConsultarDiasFestivos()%>";

        var i = 0;
        var fecha = new Array();

        var parrafo = document.getElementById("lblDiasCapacitacion");
        parrafo.innerHTML = 0;

        var posComas = 0;
        var contador = 0;
        var ini = 0;
        var posComasV = new Array;

        for (var iCont = 0 ; iCont < diaFestivo.length ; iCont++) {
            if (diaFestivo.charAt(iCont) == ",") {
                posComasV[contador] = iCont;
                contador++;
            }
        }

        for (var x = 0; x < posComasV.length; x++) {
            fecha[x] = diaFestivo.substring(ini, posComasV[x]);
            ini = posComasV[x] + 1;
        }
        //validar si las fechas son validas
        if ((blnValidarCampo(document.forms('SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones').elements('txtCapacitacionInicio'), false, 'txtCapacitacionInicio', cintTipoCampoFecha, 10, 10, '')) && (blnValidarCampo(document.forms('SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones').elements('txtCapacitacionFin'), false, 'txtCapacitacionFin', cintTipoCampoFecha, 10, 10, ''))) {

            var fFestivas = new Array();
            for (var i = 0; i < fecha.length; i++) {
                fFestivas[i] = fecha[i];
            }

            var fdbIni = new Date(fFestivas[0]);
            var contDiasFestivos = 0;//contiene el numero de dias festivos implecitos en un rango de fechas						

            var diasEntreFechas = eval(((((fFin - fIni) / 60) / 60) / 24) / 1000) + 1;//segundos,minutos,horas...				

            if (fFin > fdbIni) {

                var diaSemanaFechaFestiva = 0;
                for (var i = 0; i < fFestivas.length; i++) {
                    diaFestivo = new Date(fFestivas[i]);
                    diaSemanaFechaFestiva = 1 + diaFestivo.getDay();

                    if ((fFin >= diaFestivo) && (fIni <= diaFestivo))
                        if (diaSemanaFechaFestiva != diaDescanso)//si dia descanso = dia festivo solo se restará el dia para el dia de descanso y no ambos
                            contDiasFestivos++;
                }
            }

            var diaSemana = 0
            var UnDiaEnMiliSegundos = parseInt(1 * 24 * 60 * 60 * 1000);//milisegundos de un dia					

            var diafIni = 0
            var contDiasDescanso = 0;

            for (var i = 0; i < diasEntreFechas; i++) {
                diaSemana = 1 + fIni.getDay();
                if (diaSemana == diaDescanso)
                    contDiasDescanso++;
                fIni.setTime(parseInt(fIni.getTime() + UnDiaEnMiliSegundos));
            }

            //Actualizando pantalla

            var dias = Math.floor(diasEntreFechas - contDiasDescanso - contDiasFestivos);

            parrafo.innerHTML = dias;
        }
    }
}//fin de carga de vacaciones

function strGetCustomDateTime() {
    document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")%>");
    return (true);
}

function strUsuarioNombre() {
    document.write("<%=strUsuarioNombre%>");
    return (true);
}
function cmdAplicar_onclick() {
    var intEmpId = "<%=Convert.ToDouble(Request.QueryString("intEmpleadoId"))%>";
    //validar Vacaciones

    var fIni = document.forms[0].elements["txtVacacionesInicio"].value;
    var fFin = document.forms[0].elements["txtVacacionesFin"].value;

    if (fIni != "" || fFin != "") {
        if (fIni == "") {
            alert("En vacaciones falta información, favor de verificar");
            document.forms[0].elements["txtVacacionesInicio"].focus();
            return false;
        }

        if (fFin == "") {
            alert("En vacaciones falta información, favor de verificar");
            document.forms[0].elements["txtVacacionesInicio"].focus();
            return false;
        }
    }

    //Validar Dia Descanso
    var diaDescanso = document.forms[0].elements["cmdDiaDescanso"].value // se obtiene el dia de descanso de lo que diga el combo dia de descanso
    if (diaDescanso == "0") {
        alert("Debe seleccionar un día de descanso para continuar");
        document.forms[0].elements["cmdDiaDescanso"].focus();
        return false;
    }
    else {

        //
        var strGrupo = "<%= strGrupoDescripcion()%>";
	    if ((strGrupo == 'ADMINISTRATIVO') && (diaDescanso != '1')) {

	        //document.forms[0].elements["cmdDiaDescanso"].value = '1';
	        alert('El dia de descanso para el empleado administrativo siempre debe de ser el domingo.');
	        document.forms[0].elements["cmdDiaDescanso"].focus();
	        return (false);
	    }
	    //
	}

    //Validar Incapacidad Medica
    var fIni = document.forms[0].elements["txtIncapacidadMedicaInicio"].value
    var fFin = document.forms[0].elements["txtIncapacidadMedicaFinal"].value

    if (fIni != "" || fFin != "") {
        if (fIni == "") {
            alert("En incapacidad médica falta información, favor de verificar");
            document.forms[0].elements["txtIncapacidadMedicaInicio"].focus();
            return false;
        }
        if (fFin == "") {
            alert("En incapacidad médica falta información, favor de verificar");
            document.forms[0].elements["txtIncapacidadMedicaFinal"].focus();
            return false;
        }

        if (document.forms[0].elements["txtFolio"].value == "") {
            alert("En incapacidad médica falta folio, favor de verificar");
            document.forms[0].elements["txtFolio"].focus();
            return false;
        }

    }
    if ((fIni == "" || fFin == "") && document.forms[0].elements["txtFolio"].value != "") {
        alert("No es posible almacenar el número de folio sin fechas de inicio y fin de incapacidad, favor de verificar");
        document.forms[0].elements["txtFolio"].focus();
        return false;
    }

    //Validar Permiso Especial
    fIni = document.forms[0].elements["txtPermisoEspecialInicio"].value;
    fFin = document.forms[0].elements["txtPermisoEspecialFin"].value;

    if (fIni != "" || fFin != "") {
        if (fIni == "") {
            alert("En permiso especial falta información, favor de verificar");
            document.forms[0].elements["txtPermisoEspecialInicio"].focus();
            return false;
        }
        if (fFin == "") {
            alert("En permiso especial falta información, favor de verificar");
            document.forms[0].elements["txtPermisoEspecialInicio"].focus();
            return false;
        }
    }

    //Validar capacitacion
    var fIni = document.forms[0].elements["txtCapacitacionInicio"].value;
    var fFin = document.forms[0].elements["txtCapacitacionFin"].value;

    if (fIni != "" || fFin != "") {
        if (fIni == "") {
            alert("En capacitacion falta información, favor de verificar");
            document.forms[0].elements["txtCapacitacionInicio"].focus();
            return false;
        }
        if (fFin == "") {
            alert("En capacitacion falta información, favor de verificar");
            document.forms[0].elements["txtCapacitacionInicio"].focus();
            return false;
        }
    }

    if (fnValidarFechasCapacitacion() == true) {

        document.forms[0].action = "<%=strFormAction%>?strCmd=Aplicar&intEmpleadoId=" + intEmpId;
	    document.forms[0].submit();
	    document.forms[0].target = '';
	    return (true);
	}
}

function cmdTurnos_onclick() {

    var intEmpId =<%=Convert.ToDouble(Request.QueryString("intEmpleadoId"))%>    
	document.location.href = "SucursalEmpleadosControlAsistenciasAdministracionEmpleadosTurnos.aspx?intEmpleadoId=" + intEmpId;
    return true;
}

function cmdRegresar_onclick() {
    document.location.href = "SucursalEmpleadosControlAsistenciasAdministraciondeEmpleados.aspx";
}


function mostrarCalendario(nombreText) {
    //Validacion del dia de descanso.
    var strGrupo = "<%= strGrupoDescripcion()%>";
    if ((strGrupo == 'ADMINISTRATIVO') && (document.forms[0].elements["cmdDiaDescanso"].value != '1')) {

        //document.forms[0].elements["cmdDiaDescanso"].value = '1';
        alert('El dia de descanso para el empleado administrativo siempre debe de ser el domingo, seleccionelo primero.');
        document.forms[0].elements["cmdDiaDescanso"].focus();
        return (false);
    }

    if (nombreText == "txtPermisoEspecialInicio") {
        if (document.forms[0].elements["txtPermisoEspecialInicio"].disabled == false) {
            if (blnValidarCampo(document.forms('SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones').elements('txtPermisoEspecialInicio'), false, 'Permiso Especial Fecha Inicio', cintTipoCampoFecha, 10, 10, '')) {
                objCalendarPermisoEspecialInicio.popup();
                //var obj_calwindow = window.open("", "Calendar")				 			
                while (objCalendarPermisoEspecialInicio.obj_calwindow1.closed == false) {
                    //perder tiempo		  
                }
                cambioPermisoEspecialFechaInicio()

            }
        }
    }

    if (nombreText == "txtPermisoEspecialFin") {
        if (document.forms[0].elements["txtPermisoEspecialFin"].disabled == false) {
            if (blnValidarCampo(document.forms('SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones').elements('txtPermisoEspecialFin'), false, 'PermisoEspecial Fecha Fin', cintTipoCampoFecha, 10, 10, '')) {
                objCalendarPermisoEspecialFin.popup();
                //var obj_calwindow = window.open("", "Calendar")				 			
                while (objCalendarPermisoEspecialFin.obj_calwindow1.closed == false) {
                    //perder tiempo		  
                }
                cambioPermisoEspecialFechaFin();
            }
        }
    }

    if (nombreText == "txtIncapacidadMedicaFinal") {
        if (document.forms[0].elements["txtIncapacidadMedicaFinal"].disabled == false) {
            if (blnValidarCampo(document.forms('SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones').elements('txtIncapacidadMedicaFinal'), false, 'Incapacidad Medica Fecha Fin', cintTipoCampoFecha, 10, 10, '')) {
                objCalendarIncapacidadMedicaFin.popup();
                //var obj_calwindow = window.open("", "Calendar")				 			
                while (objCalendarIncapacidadMedicaFin.obj_calwindow1.closed == false) {
                    //perder tiempo		  
                }
                cambioIncapacidadFechaFin()

            }
        }
    }

    if (nombreText == "txtIncapacidadMedicaInicio") {
        if (document.forms[0].elements["txtIncapacidadMedicaInicio"].disabled == false) {
            if (blnValidarCampo(document.forms('SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones').elements('txtIncapacidadMedicaInicio'), false, 'Incapacidad Fecha Inicio', cintTipoCampoFecha, 10, 10, '')) {
                objCalendarIncapacidadMedicaInicio.popup();
                //var obj_calwindow = window.open("", "Calendar")				 			
                //while(objCalendarIncapacidadMedicaInicio.popup.obj_calwindow1.closed==false)
                while (objCalendarIncapacidadMedicaInicio.obj_calwindow1.closed == false) {
                    //perder tiempo		  
                }
                cambioIncapacidadFechaInicio();
            }
        }
    }


    if (nombreText == "txtVacacionesInicio") {
        if (document.forms[0].elements["txtVacacionesInicio"].disabled == false) {
            if (blnValidarCampo(document.forms('SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones').elements('txtVacacionesInicio'), false, 'Vacaciones Fecha Inicio', cintTipoCampoFecha, 10, 10, '')) {
                objCalendarVacacionesInicio.popup();
                //var obj_calwindow = window.open("", "Calendar")				 			
                while (objCalendarVacacionesInicio.obj_calwindow1.closed == false) {
                    //perder tiempo		  
                }
                cambioVacacionesFechaInicio();
            }

        }
    }


    if (nombreText == "txtVacacionesFin") {
        if (document.forms[0].elements["txtVacacionesFin"].disabled == false) {
            if (blnValidarCampo(document.forms('SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones').elements('txtVacacionesFin'), false, 'Vacaciones Fecha Fin', cintTipoCampoFecha, 10, 10, '')) {
                objCalendarVacacionesFin.popup();
                //var obj_calwindow = window.open("", "Calendar")				 
                while (objCalendarVacacionesFin.obj_calwindow1.closed == false) {
                    //perder tiempo		  
                }
                cambioVacacionesFin();
            }
        }
    }

    if (nombreText == "txtCapacitacionInicio") {
        if (document.forms[0].elements["txtCapacitacionInicio"].disabled == false) {
            if (blnValidarCampo(document.forms('SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones').elements('txtCapacitacionInicio'), false, 'Capacitacion Fecha Inicio', cintTipoCampoFecha, 10, 10, '')) {
                objCalendarCapacitacionInicio.popup();
                //var obj_calwindow = window.open("", "Calendar")				 			
                while (objCalendarCapacitacionInicio.obj_calwindow1.closed == false) {
                    //perder tiempo		  
                }

                cambioCapacitacionFechaInicio();
            }

        }
    }

    if (nombreText == "txtCapacitacionFin") {
        if (document.forms[0].elements["txtCapacitacionFin"].disabled == false) {
            if (blnValidarCampo(document.forms('SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones').elements('txtCapacitacionFin'), false, 'Capacitacion Fecha Fin', cintTipoCampoFecha, 10, 10, '')) {
                objCalendarCapacitacionFin.popup();
                //var obj_calwindow = window.open("", "Calendar")				 
                while (objCalendarCapacitacionFin.obj_calwindow1.closed == false) {
                    //perder tiempo		  
                }
                cambioCapacitacionFin();
            }
        }
    }
}

// validacion fechas capacitacion
function cambioCapacitacionFechaInicio() {

    if ((document.forms[0].elements["txtCapacitacionInicio"].value != "") && (document.forms[0].elements["txtCapacitacionFin"].value != "")) {
        var fIni = document.forms[0].elements["txtCapacitacionInicio"].value
        var fFin = document.forms[0].elements["txtCapacitacionFin"].value

        var strDia = fIni.substring(0, 2);
        var strMes = fIni.substring(3, 5);
        var strAno = fIni.substring(6, 10);

        var fIni = new Date(strMes + "/" + strDia + "/" + strAno);

        var strDia = fFin.substring(0, 2);
        var strMes = fFin.substring(3, 5);
        var strAno = fFin.substring(6, 10);

        var fFin = new Date(strMes + "/" + strDia + "/" + strAno);


        var diaDescanso = document.forms[0].elements["cmdDiaDescanso"].value // se obtiene el dia de descanso de lo que diga el combo dia de descanso

        var diaFestivoArray = new Array();
        var diaFestivo = "<%=ConsultarDiasFestivos()%>";

        var i = 0;
        var fecha = new Array();
        var parrafo = document.getElementById("lblDiasCapacitacion");
        //parrafo.innerHTML=0;								
        var posComas = 0;
        var contador = 0;
        var ini = 0;
        var posComasV = new Array;

        for (var iCont = 0 ; iCont < diaFestivo.length; iCont++) {
            if (diaFestivo.charAt(iCont) == ",") {
                posComasV[contador] = iCont;
                contador++;
            }
        }

        for (var x = 0; x < posComasV.length; x++) {
            fecha[x] = diaFestivo.substring(ini, posComasV[x]);
            ini = posComasV[x] + 1;
        }

        //validar si las fechas son validas
        if ((blnValidarCampo(document.forms('SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones').elements('txtCapacitacionInicio'), false, 'txtCapacitacionInicio', cintTipoCampoFecha, 10, 10, '')) && (blnValidarCampo(document.forms('SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones').elements('txtCapacitacionFin'), false, 'txtCapacitacionFin', cintTipoCampoFecha, 10, 10, ''))) {
            if (fFin != "") {
                if (fIni <= fFin) {
                    fFestivas = new Array();
                    for (var i = 0; i < fecha.length; i++) {
                        fFestivas[i] = fecha[i];
                    }
                    var fdbIni = new Date(fFestivas[0]);
                    var contDiasFestivos = 0;//contiene el numero de dias festivos que se encuentran en un rango de fechas						
                    var diaFestivo;


                    var diasEntreFechas = eval(((((fFin - fIni) / 60) / 60) / 24) / 1000) + 1;//segundos,minutos,horas...

                    if (fFin > fdbIni) {
                        var diaSemanaFechaFestiva = 0;
                        for (var i = 0; i < fFestivas.length; i++) {
                            diaFestivo = new Date(fFestivas[i]);
                            diaSemanaFechaFestiva = 1 + diaFestivo.getDay();
                            if ((fFin >= diaFestivo) && (fIni <= diaFestivo))
                                if (diaSemanaFechaFestiva != diaDescanso)//si dia descanso = dia festivo solo se restará el dia para el dia de descanso y no ambos
                                    contDiasFestivos++;
                        }
                    }

                    //dias a descontar por ser dias de descanso
                    var diaSemana = 0
                    var UnDiaEnMiliSegundos = parseInt(1 * 24 * 60 * 60 * 1000);//milisegundos de un dia										
                    var diafIni = 0
                    var contDiasDescanso = 0;

                    for (var i = 0; i < diasEntreFechas; i++) {
                        diaSemana = 1 + fIni.getDay();
                        if (diaSemana == diaDescanso)
                            contDiasDescanso++;
                        fIni.setTime(parseInt(fIni.getTime() + UnDiaEnMiliSegundos));
                    }

                    //Actualizando pantalla
                    var lblDiasCapacitacion = document.getElementById("lblDiasCapacitacion");
                    var dias = Math.floor(diasEntreFechas - contDiasDescanso - contDiasFestivos);
                    //    var diasDisponibles = "<=ConsultaArray(0)%>";
                    //if(diasDisponibles >= dias && dias >= 0)					
                    lblDiasCapacitacion.innerHTML = dias;
                    //else
                    //{
                    //    alert("El número de días ha excedido a los disponibles");
                    //    lblDiasCapacitacion.innerHTML = 0;	
                    //    document.forms[0].elements["txtCapacitacionInicio"].value = "";					  
                    //    document.forms[0].elements["txtCapacitacionInicio"].focus();					  
                    //}							
                }
                else {
                    alert("La fecha final de capacitacion no puede ser menor a la fecha inicial");
                    document.forms[0].elements["txtCapacitacionInicio"].value = "";
                    document.forms[0].elements["txtCapacitacionInicio"].focus();
                }
            }

        }
    }
    else if (document.forms[0].elements["txtCapacitacionInicio"].value != "") {

        //var fIni = document.forms[0].elements["txtCapacitacionInicio"].value
        var dtmInicio = document.forms[0].elements["txtCapacitacionInicio"].value;
        //var dtmInicio = document.getElementById(txtCapacitacionInicio).value;
        var diaIni = dtmInicio.substring(0, 2)
        var mesIni = dtmInicio.substring(3, 5);
        var anioIni = dtmInicio.substring(6, 10);

        //Fecha hoy
        var dtmActual = document.getElementById("dtmFechaActual").value;
        var diaActual = dtmActual.substring(0, 2);
        var mesActual = dtmActual.substring(3, 5);
        var anioActual = dtmActual.substring(6, 10);

        var date1 = (anioIni + mesIni + diaIni);
        //var date2 = (anioFin + mesFin + diaFin);
        var date3 = (anioActual + mesActual + diaActual);

        //Validaciones si no es el dia de descanso.
        var dateIni = new Date(anioIni + "/" + mesIni + "/" + diaIni);
        var dateIniDay = dateIni.getDay();
        var diaDescanso = document.forms[0].elements["cmdDiaDescanso"].value // se obtiene el dia de descanso de lo que diga el combo dia de descanso

        if (date1 < date3) {

            alert('La capacitacion no puede ser menor al dia de hoy');
            document.forms[0].elements["txtCapacitacionInicio"].value = '';
            document.forms[0].elements["txtCapacitacionInicio"].focus;
            return (false);
        }
        else if ((dateIniDay + 1) == diaDescanso) {

            alert('La capacitacion no puede ser el dia de descanso');
            document.forms[0].elements["txtCapacitacionInicio"].value = '';
            document.forms[0].elements["txtCapacitacionInicio"].focus;
            return (false);
        }
        else if (dateIniDay == 0) {

            alert('La capacitacion no puede ser en domingo');
            document.forms[0].elements["txtCapacitacionInicio"].value = '';
            document.forms[0].elements["txtCapacitacionInicio"].focus;
            return (false);
        }
        //else if(dateIniDay  <= ){

        //}

    }
}

function fnValidarFechasCapacitacion() {

    //Fechas de Vacaciones
    var dtVacacionesInicio = trim(document.getElementById("txtVacacionesInicio").value);
    var dtVacacionesFin = trim(document.getElementById("txtVacacionesFin").value);

    if (dtVacacionesInicio != '' && dtVacacionesFin != '') {

        var diaVacacionesInicio = dtVacacionesInicio.substring(0, 2);
        var mesVacacionesInicio = dtVacacionesInicio.substring(3, 5);
        var anioVacacionesInicio = dtVacacionesInicio.substring(6, 10);
        var dateVacaciones1 = (anioVacacionesInicio + mesVacacionesInicio + diaVacacionesInicio);

        var diaVacacionesFin = dtVacacionesFin.substring(0, 2);
        var mesVacacionesFin = dtVacacionesFin.substring(3, 5);
        var anioVacacionesFin = dtVacacionesFin.substring(6, 10);
        var dateVacaciones2 = (anioVacacionesFin + mesVacacionesFin + diaVacacionesFin);
    }


    //Fechas de Incapacidad
    var dtIncapacidadInicio = trim(document.getElementById("txtIncapacidadMedicaInicio").value);
    var dtIncapacidadFin = trim(document.getElementById("txtIncapacidadMedicaFinal").value);

    if (dtIncapacidadInicio != '' && dtIncapacidadFin != '') {

        var diaIncapacidadInicio = dtIncapacidadInicio.substring(0, 2);
        var mesIncapacidadInicio = dtIncapacidadInicio.substring(3, 5);
        var anioIncapacidadInicio = dtIncapacidadInicio.substring(6, 10);
        var dateIncapacidad1 = (anioIncapacidadInicio + mesIncapacidadInicio + diaIncapacidadInicio);

        var diaIncapacidadFin = dtIncapacidadFin.substring(0, 2);
        var mesIncapacidadFin = dtIncapacidadFin.substring(3, 5);
        var anioIncapacidadFin = dtIncapacidadFin.substring(6, 10);
        var dateIncapacidad2 = (anioIncapacidadFin + mesIncapacidadFin + diaIncapacidadFin);
    }


    //Fecha Permiso
    var dtPermisoInicio = trim(document.getElementById("txtPermisoEspecialInicio").value);
    var dtPermisoFin = trim(document.getElementById("txtPermisoEspecialFin").value);

    if (dtPermisoInicio != '' && dtPermisoFin != '') {

        var diaPermisoInicio = dtPermisoInicio.substring(0, 2);
        var mesPermisoInicio = dtPermisoInicio.substring(3, 5);
        var anioPermisoInicio = dtPermisoInicio.substring(6, 10);
        var datePermiso1 = (anioPermisoInicio + mesPermisoInicio + diaPermisoInicio);

        var diaPermisoFin = dtPermisoFin.substring(0, 2);
        var mesPermisoFin = dtPermisoFin.substring(3, 5);
        var anioPermisoFin = dtPermisoFin.substring(6, 10);
        var datePermiso2 = (anioPermisoFin + mesPermisoFin + diaPermisoFin);
    }


    //Fecha Capacitacion
    var dtCapacitacionInicio = trim(document.getElementById("txtCapacitacionInicio").value);
    var dtCapacitacionFin = trim(document.getElementById("txtCapacitacionFin").value);

    if (dtCapacitacionInicio != '' && dtCapacitacionFin != '') {

        var diaCapacitacionInicio = dtCapacitacionInicio.substring(0, 2);
        var mesCapacitacionInicio = dtCapacitacionInicio.substring(3, 5);
        var anioCapacitacionInicio = dtCapacitacionInicio.substring(6, 10);
        var dateCapacitacion1 = (anioCapacitacionInicio + mesCapacitacionInicio + diaCapacitacionInicio);

        var diaCapacitacionFin = dtCapacitacionFin.substring(0, 2);
        var mesCapacitacionFin = dtCapacitacionFin.substring(3, 5);
        var anioCapacitacionFin = dtCapacitacionFin.substring(6, 10);
        var dateCapacitacion2 = (anioCapacitacionFin + mesCapacitacionFin + diaCapacitacionFin);
    }

    //Inicia validacion de Capaticacion 
    if (dateCapacitacion1 != '' && dateCapacitacion2 != '') {

        //Capacitacion vs Vacaciones
        if (dateVacaciones1 != '' && dateVacaciones2 != '') {

            if (dateCapacitacion1 >= dateVacaciones1 && dateCapacitacion1 <= dateVacaciones2) {

                alert('La capacitacion no se puede asignar el mismo dia que las vacaciones');
                return (false);
            }
            else if (dateCapacitacion2 >= dateVacaciones1 && dateCapacitacion2 <= dateVacaciones2) {

                alert('La capacitacion no se puede asignar el mismo dia que las vacaciones');
                return (false);
            }
        }

        //Capacitacion vs Incapacidad
        if (dateIncapacidad1 != '' && dateIncapacidad2 != '') {

            if (dateCapacitacion1 >= dateIncapacidad1 && dateCapacitacion1 <= dateIncapacidad2) {

                alert('La capacitacion no se puede asignar el mismo dia que la incapacidad');
                return (false);
            }
            else if (dateCapacitacion2 >= dateIncapacidad1 && dateCapacitacion2 <= dateIncapacidad2) {

                alert('La capacitacion no se puede asignar el mismo dia que la incapacidad');
                return (false);
            }
        }

        //Capacitacion vs Permiso
        if (datePermiso1 != '' && datePermiso2 != '') {

            if (dateCapacitacion1 >= datePermiso1 && dateCapacitacion1 <= datePermiso2) {

                alert('La capacitacion no se puede asignar el mismo dia que el permiso');
                return (false);
            }
            else if (dateCapacitacion2 >= datePermiso1 && dateCapacitacion2 <= datePermiso2) {

                alert('La capacitacion no se puede asignar el mismo dia que el permiso');
                return (false);
            }
        }
    }

    return (true);
}

function cambioCapacitacionFin() {

    if ((document.forms[0].elements["txtCapacitacionInicio"].value != "") && (document.forms[0].elements["txtCapacitacionFin"].value != "")) {

        var fIni = document.forms[0].elements["txtCapacitacionInicio"].value
        var fFin = document.forms[0].elements["txtCapacitacionFin"].value

        var strDia = fIni.substring(0, 2);
        var strMes = fIni.substring(3, 5);
        var strAno = fIni.substring(6, 10);

        var fIni = new Date(strMes + "/" + strDia + "/" + strAno);

        var strDia = fFin.substring(0, 2);
        var strMes = fFin.substring(3, 5);
        var strAno = fFin.substring(6, 10);

        var fFin = new Date(strMes + "/" + strDia + "/" + strAno);

        var fechaActual = new Date();
        var diasEntreFechas = eval(((((fFin - fechaActual) / 60) / 60) / 24) / 1000) + 1;

        if (diasEntreFechas <= 0) {
            alert("La fecha de fin de capacitacion no puede ser menor a la actual ");
            document.forms[0].elements["txtCapacitacionFin"].focus();
            document.forms[0].elements["txtCapacitacionFin"].value = "";
            return false;

        }

        //  diaDescanso="<%=ConsultaArray(1)%>";				
            var diaDescanso = document.forms[0].elements["cmdDiaDescanso"].value // se obtiene el dia de descanso de lo que diga el combo dia de descanso

            var diaFestivoArray = new Array();
            var diaFestivo = "<%=ConsultarDiasFestivos()%>";

	    var i = 0;
	    var fecha = new Array();
	    var parrafo = document.getElementById("lblDiasCapacitacion");
	    parrafo.innerHTML = 0;
	    var posComas = 0;
	    var contador = 0;
	    var ini = 0;
	    var posComasV = new Array;

	    for (var iCont = 0 ; iCont < diaFestivo.length ; iCont++) {
	        if (diaFestivo.charAt(iCont) == ",") {
	            posComasV[contador] = iCont;
	            contador++;
	        }
	    }

	    for (var x = 0; x < posComasV.length; x++) {
	        fecha[x] = diaFestivo.substring(ini, posComasV[x]);
	        ini = posComasV[x] + 1;
	    }

            //validar si las fechas son validas
	    if ((blnValidarCampo(document.forms('SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones').elements('txtCapacitacionInicio'), false, 'txtCapacitacionInicio', cintTipoCampoFecha, 10, 10, '')) && (blnValidarCampo(document.forms('SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones').elements('txtCapacitacionFin'), false, 'txtCapacitacionFin', cintTipoCampoFecha, 10, 10, ''))) {
	        if (fIni != "") {
	            if (fIni <= fFin) {
	                fFestivas = new Array();
	                for (var i = 0; i < fecha.length; i++) {
	                    fFestivas[i] = fecha[i];
	                }
	                var fdbIni = new Date(fFestivas[0]);
	                var contDiasFestivos = 0;//contiene el numero de dias festivos implecitos en un rango de fechas						
	                var diaFestivo;
	                var diasEntreFechas = eval(((((fFin - fIni) / 60) / 60) / 24) / 1000) + 1;//segundos,minutos,horas...

	                if (fFin > fdbIni) {
	                    var diaSemanaFechaFestiva = 0;
	                    for (var i = 0; i < fFestivas.length; i++) {
	                        diaFestivo = new Date(fFestivas[i]);
	                        diaSemanaFechaFestiva = 1 + diaFestivo.getDay();

	                        if ((fFin >= diaFestivo) && (fIni <= diaFestivo))
	                            if (diaSemanaFechaFestiva != diaDescanso)//si dia descanso = dia festivo solo se restará el dia para el dia de descanso y no ambos
	                                contDiasFestivos++;
	                    }
	                }
	                //dias a descontar por ser dias de descanso
	                var diaSemana = 0
	                var UnDiaEnMiliSegundos = parseInt(1 * 24 * 60 * 60 * 1000);//milisegundos de un dia										
	                var diafIni = 0
	                var contDiasDescanso = 0;

	                for (var i = 0; i < diasEntreFechas; i++) {
	                    diaSemana = 1 + fIni.getDay();
	                    if (diaSemana == diaDescanso)
	                        contDiasDescanso++;
	                    fIni.setTime(parseInt(fIni.getTime() + UnDiaEnMiliSegundos));
	                }
	                //Actualizando pantalla
	                var dias = Math.floor(diasEntreFechas - contDiasDescanso - contDiasFestivos);
	                //    var diasDisponibles="<=ConsultaArray(0)%>";
	                //if(diasDisponibles>=dias && dias>=0)					
	                parrafo.innerHTML = dias;
	                //else
	                //{
	                //    alert("El número de días ha excedido a los disponibles");
	                //    parrafo.innerHTML=0;
	                //    document.forms[0].elements["txtCapacitacionFin"].value="";					  
	                //    document.forms[0].elements["txtCapacitacionFin"].focus();
	                //}				
	            }
	            else {
	                alert("La fecha final de capacitacion no puede ser menor a la fecha inicial");
	                document.forms[0].elements["txtCapacitacionFin"].value = "";
	                document.forms[0].elements["txtCapacitacionFin"].focus();
	            }
	        }

	    }
    }
    else if (document.forms[0].elements["txtCapacitacionFin"].value != "") {

        //var fIni = document.forms[0].elements["txtCapacitacionFin"].value
        var dtmFin = document.forms[0].elements["txtCapacitacionFin"].value;
        //var dtmFin = document.getElementById(txtCapacitacionFin).value;
        var diaFin = dtmFin.substring(0, 2)
        var mesFin = dtmFin.substring(3, 5);
        var anioFin = dtmFin.substring(6, 10);

        //Fecha hoy
        var dtmActual = document.getElementById("dtmFechaActual").value;
        var diaActual = dtmActual.substring(0, 2);
        var mesActual = dtmActual.substring(3, 5);
        var anioActual = dtmActual.substring(6, 10);


        var date2 = (anioFin + mesFin + diaFin);
        var date3 = (anioActual + mesActual + diaActual);

        //Validaciones si no es el dia de descanso.
        var dateFin = new Date(anioFin + "/" + mesFin + "/" + diaFin);
        var dateFinDay = dateFin.getDay();
        var diaDescanso = document.forms[0].elements["cmdDiaDescanso"].value // se obtiene el dia de descanso de lo que diga el combo dia de descanso

        if (date2 < date3) {

            alert('La capacitacion no puede ser menor al dia de hoy');
            document.forms[0].elements["txtCapacitacionFin"].value = '';
            document.forms[0].elements["txtCapacitacionFin"].focus;
            return (false);
        }
        else if ((dateFinDay + 1) == diaDescanso) {

            alert('La capacitacion no puede ser el dia de descanso');
            document.forms[0].elements["txtCapacitacionFin"].value = '';
            document.forms[0].elements["txtCapacitacionFin"].focus;
            return (false);
        }
        else if (dateFinDay == 0) {

            alert('La capacitacion no puede ser en domingo');
            document.forms[0].elements["txtCapacitacionFin"].value = '';
            document.forms[0].elements["txtCapacitacionFin"].focus;
            return (false);
        }
        //else if(dateIniDay  <= ){

        //}

    }

}
// fin validacion fechas capacitacion

function cmdImprimir_onclick() {
    printContent();
    return (true);
}

function trim(stringToTrim) {
    return stringToTrim.replace(/^\s+|\s+$/g, "");
}
//-->
    </script>
</head>
<body language="javascript" leftmargin="0" topmargin="0" onload="return window_onload()" marginheight="0" marginwidth="0">
    <form name="SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones" action="about:blank" method="post">
        <table width="780" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top" height="98" width="100%">
                    <script language="JavaScript">crearTablaHeader()</script>
                </td>
            </tr>
            <tr>
                <td valign="top" height="34" width="100%">
                    <img src="../static/images/pixel.gif" width="1" height="34"></td>
            </tr>
            <tr>
                <td width="100%">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="10" bgcolor="#ffffff">
                                <img height="8" src="../static/images/pixel.gif" width="10"></td>
                            <td width="538" class="tdmigaja">
                                <div id="ToPrintTxtMigaja">
                                    <span class="txdmigaja">Está 
                en :<a class="txdmigaja" href="Sucursal.aspx">Sucursal</a> : <a class="txdmigaja" href="SucursalEmpleados.aspx">Empleado</a>
                                        : <a class="txdmigaja" href="SucursalEmpleadosControlAsistencias.aspx">Control 
                Asistencias</a> : <a class="txdmigaja" href="SucursalEmpleadosControlAsistenciasAdministraciondeEmpleados.aspx">Administración 
                de Empleados</a> : Modificaciones</span>
                                </div>
                            </td>
                            <td width="182" class="tdfechahora">
                                <script language="javascript">strGetCustomDateTime()</script>
                            </td>
                        </tr>
                        <tr>
                            <td width="10">&nbsp;</td>
                            <td width="583" valign="top">
                                <div id="ToPrintHtmContenido" align="left">
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td class="tdtablacont" valign="top" width="584">
                                                <p>
                                                    <span class="txtitulo">
                                                        <img src="../static/images/bullet_subtitulos.gif" align="middle">&nbsp;Administración 
                      de Empleados</span>
                                                </p>
                                                <script language="JavaScript">crearDatosSucursal()</script>
                                                <br>
                                                <table id="Table3" height="100%" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tr>
                                                        <td valign="top">
                                                            <table class="tdenvolventetablas" id="Table1" height="38" cellspacing="0" cellpadding="0" width="100%">
                                                                <tr>
                                                                    <td class="tdtittablas3" valign="top" align="left" colspan="2">Empleado<br>
                                                                        <script language="javascript">strllenarComboEmpleados()
                                                                        </script>
                                                                    </td>
                                                                    <td class="tdtittablas3" valign="top" align="left">Día 
                                de descanso<br>
                                                                        <script language="javascript">strDiadeDescanso()</script>
                                                                    </td>
                                                                    <td class="tdtittablas3" valign="top" align="center" bgcolor="#ffcccc">Baja 
                                Temporal<br>
                                                                        <script language="javascript">strBajaTemporal()</script>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <br>
                                                            <div class="txsubtitulo">Vacaciones</div>
                                                            <table class="tdenvolventetablas" id="Table2" height="19" cellspacing="0" cellpadding="0" width="100%">
                                                                <tr>
                                                                    <td class="tdtittablas3" align="left" width="100" height="20">Fecha 
                                Inicio:</td>
                                                                    <td class="tdtittablas3" align="left" height="20">
                                                                        <script language="javascript">strVacacionesFechaInicio()</script>
                                                                        <img style="cursor: hand" onclick="mostrarCalendario('txtVacacionesInicio')" src="../static/images/icono_calendario.gif">
                                                                    </td>
                                                                    <td class="tdtittablas3" align="left" colspan="2" height="26"></td>
                                                                    <td class="tdtittablas3" align="right" width="100" height="20">Días 
                                Disponibles:</td>
                                                                    <td class="tdtittablas3" align="left" height="20">
                                                                        <script language="javascript">strDiasDisponiblesVacaciones()</script>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="tdtittablas3" align="left" width="100" height="20">Fecha 
                                Fin:</td>
                                                                    <td class="tdtittablas3" align="left" height="20">
                                                                        <script language="javascript">strVacacionesFechaFin()</script>
                                                                        <img style="cursor: hand" onclick="mostrarCalendario('txtVacacionesFin')" src="../static/images/icono_calendario.gif">
                                                                    </td>
                                                                    <td class="tdtittablas3" align="left" colspan="2" height="20"></td>
                                                                    <td class="tdtittablas3" align="right" height="20">Días 
                                Requeridos:</td>
                                                                    <td class="tdtittablas3" align="left" width="20" height="20">
                                                                        <div id="lblDias">0</div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <br>
                                                            <div class="txsubtitulo">
                                                                Incapacidad 
                            Médica
                                                            </div>
                                                            <table class="tdenvolventetablas" id="tblBusqueda" cellspacing="0" cellpadding="0" width="100%">
                                                                <tr>
                                                                    <td class="tdtittablas3" align="left" width="100" height="20">Fecha 
                                Inicio:</td>
                                                                    <td class="tdtittablas3" align="left" height="20">
                                                                        <script language="javascript">strIncapacidadMedicaFechaInicio()</script>
                                                                        <img style="cursor: hand" onclick="mostrarCalendario('txtIncapacidadMedicaInicio')" src="../static/images/icono_calendario.gif">
                                                                    </td>
                                                                    <td class="tdtittablas3" align="right" height="20">Folio:</td>
                                                                    <td class="tdtittablas3" align="left" height="20">
                                                                        <script language="javascript">strIncapacidadMedicaFolio()</script>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="tdtittablas3" align="left" width="100" height="20">Fecha 
                                Fin:</td>
                                                                    <td class="tdtittablas3" align="left" height="20">
                                                                        <script language="javascript">strIncapacidadMedicaFechaFin()</script>
                                                                        <img style="cursor: hand" onclick="mostrarCalendario('txtIncapacidadMedicaFinal')" src="../static/images/icono_calendario.gif">
                                                                    </td>
                                                                    <td class="tdtittablas3" align="right" width="100" height="20">Motivo:</td>
                                                                    <td colspan="4">
                                                                        <script language="javascript">strIncapacidadMedicaMotivos()</script>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <table>
                                                                <tr>
                                                                    <td class="tdtittablas3" align="left" colspan="2">
                                                                        <input class="boton" onclick="if (document.getElementById('changeDefault').style.display == 'block') document.getElementById('changeDefault').style.display = 'none'; else document.getElementById('changeDefault').style.display = 'block';" type="button" value="Observaciones" name="btnObservacionesIncapacidad">
                                                                        <div id="changeDefault" style="display: none">
                                                                            <script language="javascript">strObservacionesIncapacidad()</script>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <br>
                                                            <div class="txsubtitulo">
                                                                Permiso 
                            Especial
                                                            </div>
                                                            <table class="tdenvolventetablas" id="tblBusqueda" cellspacing="0" cellpadding="0" width="100%">
                                                                <tr>
                                                                    <td class="tdtittablas3" align="left" width="100" height="20">Fecha 
                                Inicio:</td>
                                                                    <td class="tdtittablas3" align="left" height="20">
                                                                        <script language="javascript">strPermisoEspecialFechaInicio()</script>
                                                                        <img style="cursor: hand" onclick="mostrarCalendario('txtPermisoEspecialInicio')" src="../static/images/icono_calendario.gif">
                                                                    </td>
                                                                    <td class="tdtittablas3" align="right" height="20">Días:</td>
                                                                    <td class="tdtittablas3" align="left" height="60">
                                                                        <div id="lblDiasPermiso">0</div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="tdtittablas3" align="left" width="100" height="20">Fecha 
                                Fin:</td>
                                                                    <td class="tdtittablas3" align="left" height="20">
                                                                        <script language="javascript">strPermisoEspecialFechaFin()</script>
                                                                        <img style="cursor: hand" onclick="mostrarCalendario('txtPermisoEspecialFin')" src="../static/images/icono_calendario.gif">
                                                                    </td>
                                                                    <td class="tdtittablas3" align="right" height="20">Con 
                                sueldo:</td>
                                                                    <td class="tdtittablas3" align="left" height="60">
                                                                        <script language="javascript">strPermisoEspecialConSueldo()</script>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <table>
                                                                <tr>
                                                                    <td class="tdtittablas3" align="left" colspan="2">
                                                                        <input class="boton" onclick="if (document.getElementById('changeDefault2').style.display == 'block') document.getElementById('changeDefault2').style.display = 'none'; else document.getElementById('changeDefault2').style.display = 'block';"
                                                                            type="button" value="Observaciones" name="btnObservacionesPermiso">
                                                                        <div id="changeDefault2" style="display: none">
                                                                            <script language="javascript">strObservacionesPermiso()</script>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <input type="hidden" name="hdnDiaDescansoOriginal">
                                                            <input type="hidden" name="hdnDiaDescanso">
                                                            <input type="hidden" name="hdnMotivo">
                                                            <input type="hidden" id="dtmFechaActual" name="dtmFechaActual" value='<%= strFechaActual()%>' />
                                                        </td>
                                                    </tr>
                                                    <!--Inicia cambio Control Asistencia II-->
                                                    <tr>
                                                        <td valign="top">
                                                            <br>
                                                            <div class="txsubtitulo">Capacitación y/o Junta Operacional </div>
                                                            <table class="tdenvolventetablas" id="TABLE4" cellspacing="0" cellpadding="0" width="100%">
                                                                <tr>
                                                                    <td class="tdtittablas3" align="left" width="100" height="20">Fecha 
                                Inicio:</td>
                                                                    <td class="tdtittablas3" align="left" height="20">
                                                                        <script language="javascript">strCapacitacionFechaInicio()</script>
                                                                        <img style="cursor: hand" onclick="mostrarCalendario('txtCapacitacionInicio')" src="../static/images/icono_calendario.gif">
                                                                    </td>
                                                                    <td class="tdtittablas3" align="right" height="20">Días:</td>
                                                                    <td class="tdtittablas3" align="left" height="60">
                                                                        <div id="lblDiasCapacitacion">0</div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="tdtittablas3" align="left" width="100" height="20">Fecha 
                                Fin:</td>
                                                                    <td class="tdtittablas3" align="left" height="20">
                                                                        <script language="javascript">strCapacitacionFechaFin()</script>
                                                                        <img style="cursor: hand" onclick="mostrarCalendario('txtCapacitacionFin')" src="../static/images/icono_calendario.gif">
                                                                    </td>
                                                                    <td class="tdtittablas3" align="right" height="20"></td>
                                                                    <td class="tdtittablas3" align="left" height="60"></td>
                                                                </tr>
                                                            </table>
                                                            <table>
                                                                <tr>
                                                                    <td class="tdtittablas3" align="left" colspan="2">
                                                                        <input class="boton" onclick="if (document.getElementById('changeDefault3').style.display == 'block') document.getElementById('changeDefault3').style.display = 'none'; else document.getElementById('changeDefault3').style.display = 'block';"
                                                                            type="button" value="Observaciones" name="btnObservacionesCapacitacion">
                                                                        <div id="changeDefault3" style="display: none">
                                                                            <script language="javascript">strObtenerObservacionesCapacitacion()</script>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <%--<input type="hidden" name="hdnDiaDescansoOriginal"> 
                          <input type="hidden" name="hdnDiaDescanso"> <input type="hidden" name="hdnMotivo"> --%>
                                                        </td>
                                                    </tr>
                                                    <!--Fin cambio Control Asistencia II-->
                                                    <tr>
                                                        <td class="txsubtitulo" valign="top">
                                                            <br>
                                                            <input class="boton" id="cmdRegresar" style="width: 64px; height: 20px" onclick="return cmdRegresar_onclick()"
                                                                type="button" value="Regresar" name="cmdRegresar">
                                                            &nbsp;&nbsp;&nbsp;
                                                            <input class="boton" id="cmdImprimir" style="width: 64px; height: 20px" onclick="cmdImprimir_onclick()"
                                                                type="button" value="Imprimir" name="cmdImprimir">
                                                            &nbsp; &nbsp;
                                                            <input class="boton" id="cmdTurnos" style="width: 64px; height: 20px" onclick="return cmdTurnos_onclick()"
                                                                type="button" value="Turnos" name="cmdTurnos">
                                                            &nbsp;&nbsp;&nbsp;
                                                            <input class="boton" style="width: 64px; height: 20px" onclick="return cmdAplicar_onclick()"
                                                                type="button" value="Aplicar" name="cmdAplicar"></td>
                                                    </tr>
                                                </table>
                                                <div id="lblMensajeError" align="center">&nbsp;</div>
                                            </td>
                                        </tr>
                                    </table>
                            </td>
                            <td width="182" rowspan="2" valign="top" class="tdcolumnader">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="tdbottom" colspan="2">
                                <script language="JavaScript">crearTablaFooter()</script>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <script language="JavaScript">
	<!--
    new menu(MENU_ITEMS, MENU_POS);
    new menu(MENU_ITEMS2, MENU_POS2);
    var objCalendarVacacionesInicio = new calendar1(document.forms['SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones'].elements['txtVacacionesInicio']);
    var objCalendarVacacionesFin = new calendar1(document.forms['SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones'].elements['txtVacacionesFin']);
    var objCalendarIncapacidadMedicaInicio = new calendar1(document.forms['SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones'].elements['txtIncapacidadMedicaInicio']);
    var objCalendarIncapacidadMedicaFin = new calendar1(document.forms['SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones'].elements['txtIncapacidadMedicaFinal']);
    var objCalendarPermisoEspecialInicio = new calendar1(document.forms['SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones'].elements['txtPermisoEspecialInicio']);
    var objCalendarPermisoEspecialFin = new calendar1(document.forms['SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones'].elements['txtPermisoEspecialFin']);
    var objCalendarCapacitacionInicio = new calendar1(document.forms['SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones'].elements['txtCapacitacionInicio']);
    var objCalendarCapacitacionFin = new calendar1(document.forms['SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones'].elements['txtCapacitacionFin']);
    //-->
        </script>
    </form>
    <iframe name="ifrPageToPrint" src="../static/PageToPrint.htm" width="0" height="0"></iframe>
</body>
</html>

