<?xml version="1.0" encoding="ISO-8859-1" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html" encoding="ISO-8859-1" indent="no" media-type="text/html" />
  <xsl:template match="/NavegadorRegistros">
    <!-- Variables locales -->
    <xsl:variable name="intCuentaOperacionesNavegador" select="count(Operaciones/OperacionesNavegadorRegistros) " />
    <xsl:variable name="intCuentaOperacionesColumnas" select="count(Operaciones/OperacionesColumnas) " />
    <xsl:variable name="intPaginasTotales" select="Indicadores/Paginas/intPaginasTotales" />
    <!-- Verificamos si existe el tag de operaciones en el navegador de registro, si no se buscara el URL en las acciones, si no tiene acciones se verificara el URL que se encuentre en tag indicadores   -->
    <xsl:variable name="strURL">
      <xsl:choose>
        <xsl:when test="$intCuentaOperacionesNavegador > 0">
          <xsl:value-of select="Operaciones/OperacionesNavegadorRegistros/Operacion/strOperacionURL" />
        </xsl:when>
        <xsl:when test="$intCuentaOperacionesColumnas > 0">
          <xsl:value-of select="Operaciones/OperacionesColumnas/Operacion/strOperacionURL" />
        </xsl:when>
        <xsl:otherwise>
          <xsl:value-of select="Indicadores/Paginas/strPaginaURL" />
        </xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <!-- Inicio del HTML -->
    <br />
    
<xsl:if test="$intCuentaOperacionesColumnas>0">
    <!-- Función para eliminación de registros -->
    <script language="javascript">
        function blnRecordBrowserDeleteElement(strTargetURL) {
          if (confirm("¿Esta seguro que desea eliminar este elemento?") == true) {
            window.location.href = strTargetURL;
          }
        }
        function RecordBrowserCopyElement(strTargetURL) {
          var strAnswer = prompt('¿Cuál es el nombre del nuevo elemento?','')
          if (strAnswer) {
            window.location.href = strTargetURL + '&amp;strTipoFormaCapturaNombreCopia=' + strAnswer;
          }
        }
        </script>
              
</xsl:if>
    <!-- Muestra el encabezado principal del Navegador de Registros -->
    <span class="txsubtitulo">
      <img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absmiddle" />
      <xsl:value-of select="Encabezados/EncabezadosNavegadorRegistros/Encabezado/strEncabezadoTitulo" />
    </span>
    <br />
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
      <tr>
        <td height="4" colspan="4" bgcolor="666666">
          <img src="../static/images/pixel.gif" width="1" height="4" />
        </td>
      </tr>
      <tr>
        <td height="8" colspan="4">
          <img src="../static/images/pixel.gif" width="1" height="8" />
        </td>
      </tr>
      <tr>
        <!-- Muestra los Indicadores totales y las paginas desplegadas -->
        <td valign="middle" class="txcontenidobold">Total:
        <span class="txcontazul">
            <xsl:value-of select="Indicadores/Elementos/intElementosTotales" />
          </span>
        </td>
        <td class="txcontenidobold">Mostrando:
        <span class="txcontazul">
					<xsl:value-of select="Indicadores/Elementos/intElementoInicial" /> - <xsl:value-of select="Indicadores/Elementos/intElementoFinal" /></span>
				</td>
        <td class="txcontenidobold">Pags.
          <xsl:variable name="intNavegadorRegistrosPaginaPrimera">
						<xsl:value-of select="$strURL" />intNavegadorRegistrosPagina=1</xsl:variable>
          <!-- Se muestran los Botones de Navegacion Habilitados o Deshabilitados verificando si se tiene alguna Operacion A nivel Navegador Registros -->
          <xsl:choose>
            <xsl:when test="$intPaginasTotales > 1">
              <xsl:variable name="intPaginaAnterior">
								<xsl:value-of select="$strURL" />intNavegadorRegistrosPagina=<xsl:value-of select="Indicadores/Paginas/intPaginaAnterior" />
							</xsl:variable>
              <a href="{$intNavegadorRegistrosPaginaPrimera}">
                <img src="../static/images/icono_inicio.gif" width="17" height="17" align="absmiddle"
                  border="0" />
              </a>
              <a href="{$intPaginaAnterior}">
                <img src="../static/images/icono_back.gif" width="25" height="17" align="absmiddle" border="0" />
              </a>
            </xsl:when>
            <xsl:otherwise>
              <img src="../static/images/icono_inicio.gif" width="17" height="17" align="absmiddle"
                border="0" />
              <img src="../static/images/icono_back.gif" width="25" height="17" align="absmiddle" border="0" />
            </xsl:otherwise>
          </xsl:choose>&#160;
        <!-- Creacion de los Numeros de Páginas de Navegadores -->
          <xsl:for-each select="Indicadores/Paginas/Pagina">
            <xsl:variable name="intPaginaActual" select="../intPaginaActual" />
            <xsl:if test="current() = $intPaginaActual">
							<span class="txaccionbold">
                <xsl:value-of select="." />
              </span>&#160;&#160;</xsl:if>
            <xsl:if test="current() != $intPaginaActual">
							<xsl:variable name="strOperacionURL">
								<xsl:value-of select="$strURL" />intNavegadorRegistrosPagina=<xsl:value-of select="." />
							</xsl:variable>
							<a class="txaccion" href="{$strOperacionURL}">
                <xsl:value-of select="." />
              </a>&#160;&#160;</xsl:if>
          </xsl:for-each>
          <xsl:variable name="intPaginaSiguiente">
						<xsl:value-of select="$strURL" />intNavegadorRegistrosPagina=<xsl:value-of select="Indicadores/Paginas/intPaginaSiguiente" />
					</xsl:variable>
          <xsl:variable name="intNavegadorRegistrosPaginaUltima">
						<xsl:value-of select="$strURL" />intNavegadorRegistrosPagina=<xsl:value-of select="Indicadores/Paginas/intPaginasTotales" />
					</xsl:variable>
          <xsl:choose>
            <xsl:when test="$intPaginasTotales > 1">
              <a href="{$intPaginaSiguiente}">
                <img src="../static/images/icono_fwd.gif" width="25" height="17" align="absmiddle" border="0" />
              </a>
              <a href="{$intNavegadorRegistrosPaginaUltima}">
                <img src="../static/images/icono_final.gif" width="17" height="17" align="absmiddle"
                  border="0" />
              </a>
            </xsl:when>
            <xsl:otherwise>
              <img src="../static/images/icono_fwd.gif" width="25" height="17" align="absmiddle" border="0" />
              <img src="../static/images/icono_final.gif" width="17" height="17" align="absmiddle"
                border="0" />
            </xsl:otherwise>
          </xsl:choose>
        </td>
        <td align="right" class="tdpadleft5" id="BotonDelNavegador" >
          <xsl:variable name="strOperacionComando" select="Operaciones/OperacionesNavegadorRegistros/Operacion/strOperacionComando" />
          <xsl:variable name="strOperacionVisible" select="Operaciones/OperacionesNavegadorRegistros/Operacion/@blnVisible" />
          <xsl:if test="$intCuentaOperacionesNavegador> 0">
            <xsl:if test="$strOperacionVisible != 'false'">
              <input name="cmdNavegadorRegistrosAgregar" type="button" class="boton" id="cmdNavegadorRegistrosAgregar"
                value="{$strOperacionComando}" onclick="window.location='{$strURL}strCmd=Agregar'" />
            </xsl:if>
          </xsl:if>
        </td>
      </tr>
      <tr>
        <td height="8" colspan="4">
          <img src="../static/images/pixel.gif" width="1" height="8" />
        </td>
      </tr>
      <tr bgcolor="666666">
        <td height="4" colspan="4">
          <img src="../static/images/pixel.gif" width="1" height="4" />
        </td>
      </tr>
    </table>
    <br />
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
      <tr class="trtitulos">
        <!-- Se generan los Encabezados -->
        <xsl:for-each select="Encabezados/EncabezadosColumnas/Encabezado">
          <xsl:variable name="strAlineacionHorizontal" select="@strAlineacionHorizontal" />
          <th class="rayita" align="{$strAlineacionHorizontal}" valign="top">
            <xsl:value-of select="." />
          </th>
        </xsl:for-each>
        <xsl:variable name="intcuentaoperaciones" select="count(Operaciones/OperacionesColumnas/Operacion)" />
        <xsl:if test="$intcuentaoperaciones > 0">
          <th colspan="{$intcuentaoperaciones}" class="rayita" align="center" valign="top">Acciones</th>
        </xsl:if>
      </tr>
      <!-- Aqui se barreran los valores de cada una de las Columnas -->
      <xsl:for-each select="Registros/Registro">
        <xsl:choose>
          <xsl:when test="position() mod 2">
            <tr>
              <xsl:for-each select="Columnas/Columna">
                <xsl:variable name="strAlinea" select="strColumnaValor/@strAlineacionHorizontal" />
                <xsl:variable name="strLinkTo" select="strColumnaValor/@strLinkTo" />
                <td class="tdceleste" align="{$strAlinea}" valign="top">
									<xsl:choose>
						<xsl:when test="normalize-space(.) != $strLinkTo">
									<a href='#' onclick="{$strLinkTo}"><xsl:value-of select="strColumnaValor" /></a>&#160;
						</xsl:when>
						<xsl:otherwise>
									<xsl:value-of select="strColumnaValor" />&#160;												</xsl:otherwise>
					</xsl:choose>
				</td>
              </xsl:for-each>
              <xsl:variable name="strLlaves">
                <xsl:for-each select="Llaves/Llave">&amp;<xsl:value-of select="strLlaveNombre" />=<xsl:value-of select="strLlaveValor" />
								</xsl:for-each>
              </xsl:variable>
              <!-- Aqui se barreran las Operaciones que tienen cada uno de los Registros -->
              <xsl:for-each select="/NavegadorRegistros/Operaciones/OperacionesColumnas/Operacion">
                <xsl:variable name="strOperacionCmd" select="strOperacionComando" />
                <xsl:variable name="strOperacionDescripcion" select="strOperacionDescripcion" />
                <xsl:variable name="strOperacionURL">
                  <xsl:choose>
                    <xsl:when test="$strOperacionCmd='Eliminar'">
                                            javascript:blnRecordBrowserDeleteElement("<xsl:value-of select="strOperacionURL" />strCmd=<xsl:value-of select="$strOperacionCmd" />
                                            <xsl:value-of select="$strLlaves" />")
                                        </xsl:when>
                    <xsl:when test="$strOperacionCmd='Copiar'">
                                            javascript:RecordBrowserCopyElement("<xsl:value-of select="strOperacionURL" />strCmd=<xsl:value-of select="$strOperacionCmd" />
                                            <xsl:value-of select="$strLlaves" />")
                                        </xsl:when>
                    <xsl:otherwise>
                                            <xsl:value-of select="strOperacionURL" />strCmd=<xsl:value-of select="$strOperacionCmd" />
                                            <xsl:value-of select="$strLlaves" />
                                        </xsl:otherwise>
                  </xsl:choose>
                </xsl:variable>
                <xsl:variable name="strOperacionImagen">../static/images/imgNR<xsl:value-of select="strOperacionComando" />.gif</xsl:variable>
                <td align="center" class="tdceleste">
                  <a href="{$strOperacionURL}" class="txaccion">
                    <img src="{$strOperacionImagen}" width="13" height="13" align="absmiddle" alt="{$strOperacionDescripcion}"
                      border="0" />
                  </a>
                  <img src="../static/images/spacer.gif" width="1" height="1" />
                </td>
              </xsl:for-each>
            </tr>
          </xsl:when>
          <xsl:otherwise>
            <tr>
              <xsl:for-each select="Columnas/Columna">
                <xsl:variable name="strAlinea" select="strColumnaValor/@strAlineacionHorizontal" />
                <xsl:variable name="strLinkTo" select="strColumnaValor/@strLinkTo" />
                <td class="tdblanco" align="{$strAlinea}" valign="top">
									<xsl:choose>
						<xsl:when test="normalize-space(.) != $strLinkTo">
									<a href='#' onclick="{$strLinkTo}"><xsl:value-of select="strColumnaValor" /></a>&#160;												</xsl:when>
						<xsl:otherwise>
									<xsl:value-of select="strColumnaValor" />&#160;
						</xsl:otherwise>
					</xsl:choose>
				</td>
              </xsl:for-each>
              <xsl:variable name="strLlaves">
                <xsl:for-each select="Llaves/Llave">&amp;<xsl:value-of select="strLlaveNombre" />=<xsl:value-of select="strLlaveValor" />
								</xsl:for-each>
              </xsl:variable>
              <!-- Aqui se barreran las Operaciones que tienen cada uno de los Registros -->
              <xsl:for-each select="/NavegadorRegistros/Operaciones/OperacionesColumnas/Operacion">
                <xsl:variable name="strOperacionCmd" select="strOperacionComando" />
                <xsl:variable name="strOperacionDescripcion" select="strOperacionDescripcion" />
                <xsl:variable name="strOperacionURL">
                  <xsl:choose>
                    <xsl:when test="$strOperacionCmd='Eliminar'">
                                            javascript:blnRecordBrowserDeleteElement("<xsl:value-of select="strOperacionURL" />strCmd=<xsl:value-of select="$strOperacionCmd" />
                                            <xsl:value-of select="$strLlaves" />")
                                        </xsl:when>
                    <xsl:when test="$strOperacionCmd='Copiar'">
                                            javascript:RecordBrowserCopyElement("<xsl:value-of select="strOperacionURL" />strCmd=<xsl:value-of select="$strOperacionCmd" />
                                            <xsl:value-of select="$strLlaves" />")
                                        </xsl:when>
                    <xsl:otherwise>
                                            <xsl:value-of select="strOperacionURL" />strCmd=<xsl:value-of select="$strOperacionCmd" />
                                            <xsl:value-of select="$strLlaves" />
                                        </xsl:otherwise>
                  </xsl:choose>
                </xsl:variable>
                <xsl:variable name="strOperacionImagen">../static/images/imgNR<xsl:value-of select="strOperacionComando" />.gif</xsl:variable>
                <td align="center" class="tdblanco">
                  <a href="{$strOperacionURL}" class="txaccion">
                    <img src="{$strOperacionImagen}" width="13" height="13" align="absmiddle" alt="{$strOperacionDescripcion}"
                      border="0" />
                  </a>
                  <img src="../static/images/spacer.gif" width="1" height="1" />
                </td>
              </xsl:for-each>
            </tr>
          </xsl:otherwise>
        </xsl:choose>
      </xsl:for-each>
      <xsl:if test="count(Registros/Totales) > 0">
        <tr class="trtitulos">
          <xsl:for-each select="Registros/Totales/TitulosTotales">
            <xsl:variable name="strTituloAlineacionHorizontal" select="@strAlineacionHorizontal" />
            <th class="rayita" align="{$strTituloAlineacionHorizontal}">
              <xsl:value-of select="Titulo" />
            </th>
          </xsl:for-each>
        </tr>
      </xsl:if>
    </table>
    <!-- Final del HTML -->
  </xsl:template>
</xsl:stylesheet>
