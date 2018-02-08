using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumPhanthomjs
{
    public class nuevo2
    {


        public static int main()
        {

            var html = new HtmlDocument();

            string row = HtmlInput();

            string htmlpage = row;

            html.LoadHtml(htmlpage);
            
            var html6 = (from m in html.DocumentNode
                            .Descendants("div")
                            .Where(d =>
                                   d.Attributes.Contains("class")
                                   &&
                                   d.Attributes["class"].Value.Contains("grid-canvas")
                                   )
                            .SelectMany(tr => tr.Elements("div")
                                       .Where(p =>
                                              p.Attributes.Contains("class")
                                              &&
                                              p.ChildNodes.Count() > 1
                                              )
                             ).ToList()
                             .Select(tr => tr.Elements("div")
                                             .Select(y=> y.InnerText.Trim()
                                                    )
                                     )
                                     .ToList()
                         select m.ToList());

                      

            return 1;

        }

        private static string HtmlInput()
        {
            return @"<!DOCTYPE html>
<!--[if IE 7]> <html lang='es' class='ie ie7'> <![endif]-->
<!--[if IE 8]> <html lang='es' class='ie ie8'> <![endif]-->
<!--[if IE 9]> <html lang='es' class='ie9'> <![endif]-->
<!--[if gt IE 8]><!-->
<html lang='es' class=' js'>
<!--<![endif]-->

<head>
    <!--[if lte ie 8]><script type='text/javascript' src='/fanstatic/vendor/:version:2016-03-08T17:24:20.94/html5.min.js'></script><![endif]-->
    <link rel='stylesheet' type='text/css' href='/fanstatic/vendor/:version:2016-03-08T17:24:20.94/select2/select2.css'>
    <link rel='stylesheet' type='text/css' href='/fanstatic/ckanext-reclineview/:version:2016-09-01T16:21:30.10/vendor/bootstrap/2.3.2/css/bootstrap.css'>
    <link rel='stylesheet' type='text/css' href='/fanstatic/ckanext-reclineview/:version:2016-09-01T16:21:30.10/vendor/leaflet/0.7.3/leaflet.css'>
    <link rel='stylesheet' type='text/css' href='/fanstatic/ckanext-reclineview/:version:2016-09-01T16:21:30.10/:bundle:vendor/leaflet.markercluster/MarkerCluster.css;vendor/leaflet.markercluster/MarkerCluster.Default.css'>
    <link rel='stylesheet' type='text/css' href='/fanstatic/ckanext-reclineview/:version:2016-09-01T16:21:30.10/vendor/slickgrid/2.0.1/slick.grid.min.css'>
    <link rel='stylesheet' type='text/css' href='/fanstatic/ckanext-reclineview/:version:2016-09-01T16:21:30.10/vendor/recline/recline.css'>
    <link rel='stylesheet' type='text/css' href='/fanstatic/ckanext-reclineview/:version:2016-09-01T16:21:30.10/css/recline.min.css'>
    <meta charset='utf-8'>
    <meta name='generator' content='ckan 2.4.1'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Portal de Datos Abiertos</title>
    <link rel='shortcut icon' href='/assets/img/favicon.ico'>
    <style type='text/css' rel='stylesheet'>
        .slickgrid_185921 .slick-header-column {
            left: 1000px;
        }

        .slickgrid_185921 .slick-top-panel {
            height: 25px;
        }

        .slickgrid_185921 .slick-headerrow-columns {
            height: 25px;
        }

        .slickgrid_185921 .slick-cell {
            height: 20px;
        }

        .slickgrid_185921 .slick-row {
            height: 25px;
        }

        .slickgrid_185921 .l0 {}

        .slickgrid_185921 .r0 {}

        .slickgrid_185921 .l1 {}

        .slickgrid_185921 .r1 {}

        .slickgrid_185921 .l2 {}

        .slickgrid_185921 .r2 {}

        .slickgrid_185921 .l3 {}

        .slickgrid_185921 .r3 {}

        .slickgrid_185921 .l4 {}

        .slickgrid_185921 .r4 {}
    </style>
</head>

<body data-site-root='http://datos.gob.cl/' data-locale-root='http://datos.gob.cl/' style=''>
    <div data-module='recline_view' data-module-site_url='&quot;http://datos.gob.cl/&quot;' data-module-resource='&quot;{\&quot;cache_last_updated\&quot;: null, \&quot;package_id\&quot;: \&quot;6a19c37d-13cf-4b52-b9ca-051d14c15e6d\&quot;, \&quot;webstore_last_updated\&quot;: null, \&quot;datastore_active\&quot;: true, \&quot;id\&quot;: \&quot;2e20f930-6e71-409f-8d17-b8d4202090b7\&quot;, \&quot;size\&quot;: null, \&quot;state\&quot;: \&quot;active\&quot;, \&quot;hash\&quot;: \&quot;\&quot;, \&quot;description\&quot;: \&quot;\&quot;, \&quot;format\&quot;: \&quot;XLSX\&quot;, \&quot;mimetype_inner\&quot;: null, \&quot;url_type\&quot;: \&quot;upload\&quot;, \&quot;mimetype\&quot;: null, \&quot;cache_url\&quot;: null, \&quot;name\&quot;: \&quot;\\u00cdndices y Precios para el c\\u00e1lculo del Reajuste Polin\\u00f3mico noviembre 2017 \&quot;, \&quot;created\&quot;: \&quot;2017-12-26T15:48:31.259010\&quot;, \&quot;url\&quot;: \&quot;http://datos.gob.cl/dataset/6a19c37d-13cf-4b52-b9ca-051d14c15e6d/resource/2e20f930-6e71-409f-8d17-b8d4202090b7/download/noviembre2017.xlsx\&quot;, \&quot;webstore_url\&quot;: null, \&quot;last_modified\&quot;: \&quot;2017-12-26T18:48:31.161202\&quot;, \&quot;position\&quot;: 0, \&quot;revision_id\&quot;: \&quot;d0441ae5-d3d1-4bb7-8276-23d0d6c283ec\&quot;, \&quot;resource_type\&quot;: null}&quot;'
        ;='' data-module-resource-view='&quot;{\&quot;description\&quot;: \&quot;\&quot;, \&quot;title\&quot;: \&quot;Explorador de Datos\&quot;, \&quot;resource_id\&quot;: \&quot;2e20f930-6e71-409f-8d17-b8d4202090b7\&quot;, \&quot;view_type\&quot;: \&quot;recline_view\&quot;, \&quot;id\&quot;: \&quot;8ed64e98-b346-46a8-9987-e998f8eef5e7\&quot;, \&quot;package_id\&quot;: \&quot;6a19c37d-13cf-4b52-b9ca-051d14c15e6d\&quot;}&quot;'>
        <div class='recline-data-explorer'>
            <div class='alert-messages'></div>
            <div class='header clearfix'>
                <div class='navigation'>
                    <div class='btn-group' data-toggle='buttons-radio'>
                        <a href='#grid' data-view='grid' class='btn active'>Grid</a>
                        <a href='#graph' data-view='graph' class='btn'>Graph</a>
                        <a href='#map' data-view='map' class='btn'>Map</a>
                    </div>
                </div>
                <div class='recline-results-info'>
                    <span class='doc-count'>35</span> records </div>
                <div class='recline-pager'>
                    <div class='pagination'>
                        <ul>
                            <li class='prev action-pagination-update'>
                                <a href=''>«</a>
                            </li>
                            <li class='active'>
                                <label for='from'>From</label>
                                <a>
                                    <input name='from' type='text' value='1'> –
                                    <label for='to'>To</label>
                                    <input name='to' type='text' value='35'> </a>
                            </li>
                            <li class='next action-pagination-update'>
                                <a href=''>»</a>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class='menu-right'>
                    <div class='btn-group' data-toggle='buttons-checkbox'>
                        <a href='#' data-action='valueFilter' class='btn'>Filters</a>
                    </div>
                </div>
                <div class='query-editor-here' style='display:inline;'>
                    <div class='recline-query-editor'>
                        <form action='' method='GET' class='form-inline'>
                            <div class='input-prepend text-query'>
                                <span class='add-on'>
                                    <i class='icon-search'></i>
                                </span>
                                <label>Search</label>
                                <input type='text' name='q' value='' class='span2' placeholder='Search data ...'> </div>
                            <button type='submit' class='btn'>Go »</button>
                        </form>
                    </div>
                </div>
            </div>
            <div class='data-view-sidebar' style='display: none;'>
                <div class='editor' style='display: none;'>
                    <div class='editor'>
                        <form class='form-stacked'>
                            <div class='clearfix'>
                                <label>Tipo de Grafico</label>
                                <div class='input editor-type'>
                                    <select>
                                        <option value='lines-and-points' selected='selected'>Lines and Points</option>
                                        <option value='lines'>Lines</option>
                                        <option value='points'>Points</option>
                                        <option value='bars'>Bars</option>
                                        <option value='columns'>Columns</option>
                                    </select>
                                </div>
                                <label>Group Column (Axis 1)</label>
                                <div class='input editor-group'>
                                    <select>
                                        <option value=''>Please choose ...</option>
                                        <option value='_id'>_id</option>
                                        <option value='ITEM'>ITEM</option>
                                        <option value='D E T A L L E'>D E T A L L E</option>
                                        <option value='UNIDAD'>UNIDAD</option>
                                        <option value='V A L O R'>V A L O R</option>
                                    </select>
                                </div>
                                <div class='editor-series-group'>
                                    <div class='editor-series js-series-0'>
                                        <label>Series
                                            <span>A (Axis 2)</span> [
                                            <a href='#remove' class='action-remove-series'>Remove</a>] </label>
                                        <div class='input'>
                                            <select>
                                                <option value='_id'>_id</option>
                                                <option value='ITEM'>ITEM</option>
                                                <option value='D E T A L L E'>D E T A L L E</option>
                                                <option value='UNIDAD'>UNIDAD</option>
                                                <option value='V A L O R'>V A L O R</option>
                                            </select>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class='editor-buttons'>
                                <button class='btn editor-add'>Add Series</button>
                            </div>
                            <div class='editor-buttons editor-submit' comment='hidden temporarily' style='display: none;'>
                                <button class='editor-save'>Save</button>
                                <input type='hidden' class='editor-id' value='chart-1'> </div>
                        </form>
                    </div>
                </div>
                <div class='editor' style='display: none;'>
                    <form class='form-stacked'>
                        <div class='clearfix'>
                            <div class='editor-field-type'>
                                <label class='radio'>
                                    <input type='radio' id='editor-field-type-latlon' name='editor-field-type' value='latlon'
                                        checked='checked'> Latitude / Longitude fields</label>
                                <label class='radio'>
                                    <input type='radio' id='editor-field-type-geom' name='editor-field-type' value='geom'> GeoJSON field</label>
                            </div>
                            <div class='editor-field-type-latlon'>
                                <label>Latitude field</label>
                                <div class='input editor-lat-field'>
                                    <select>
                                        <option value=''></option>
                                        <option value='_id'>_id</option>
                                        <option value='ITEM'>ITEM</option>
                                        <option value='D E T A L L E'>D E T A L L E</option>
                                        <option value='UNIDAD'>UNIDAD</option>
                                        <option value='V A L O R'>V A L O R</option>
                                    </select>
                                </div>
                                <label>Longitude field</label>
                                <div class='input editor-lon-field'>
                                    <select>
                                        <option value=''></option>
                                        <option value='_id'>_id</option>
                                        <option value='ITEM'>ITEM</option>
                                        <option value='D E T A L L E'>D E T A L L E</option>
                                        <option value='UNIDAD'>UNIDAD</option>
                                        <option value='V A L O R'>V A L O R</option>
                                    </select>
                                </div>
                            </div>
                            <div class='editor-field-type-geom' style='display:none'>
                                <label>Geometry field (GeoJSON)</label>
                                <div class='input editor-geom-field'>
                                    <select>
                                        <option value=''></option>
                                        <option value='_id'>_id</option>
                                        <option value='ITEM'>ITEM</option>
                                        <option value='D E T A L L E'>D E T A L L E</option>
                                        <option value='UNIDAD'>UNIDAD</option>
                                        <option value='V A L O R'>V A L O R</option>
                                    </select>
                                </div>
                            </div>
                        </div>
                        <div class='editor-buttons'>
                            <button class='btn editor-update-map'>Update</button>
                        </div>
                        <div class='editor-options'>
                            <label class='checkbox'>
                                <input type='checkbox' id='editor-auto-zoom' value='autozoom' checked='checked'> Auto zoom to features</label>
                            <label class='checkbox'>
                                <input type='checkbox' id='editor-cluster' value='cluster'> Cluster markers</label>
                        </div>
                        <input type='hidden' class='editor-id' value='map-1'> </form>
                </div>
                <div class='recline-filter-editor well'>
                    <div class='filters'>
                        <h3>Filters</h3>
                        <button class='btn js-add-filter add-filter'>Add filter</button>
                        <form class='form-stacked js-add' style='display: none;'>
                            <fieldset>
                                <label>Field</label>
                                <select class='fields'>
                                    <option value='_id'>_id</option>
                                    <option value='ITEM'>ITEM</option>
                                    <option value='D E T A L L E'>D E T A L L E</option>
                                    <option value='UNIDAD'>UNIDAD</option>
                                    <option value='V A L O R'>V A L O R</option>
                                </select>
                                <button type='submit' class='btn'>Add</button>
                            </fieldset>
                        </form>
                        <form class='form-stacked js-edit'> </form>
                    </div>
                </div>
            </div>
            <div class='data-view-container'>
                <div class='recline-slickgrid slickgrid_185921 ui-widget' style='overflow: hidden; outline: 0px; position: relative;'>
                    <div tabindex='0' hidefocus='' style='position:fixed;width:0;height:0;top:0;left:0;outline:0;'></div>
                    <div class='slick-header ui-state-default' style='overflow:hidden;position:relative;'>
                        <div class='slick-header-columns ui-sortable' style='width:10000px; left:-1000px' unselectable='on'>
                            <div class='ui-state-default slick-header-column' id='slickgrid_185921_id' title='_id' style='width: 243px;'>
                                <span class='slick-column-name'>_id</span>
                                <span class='slick-sort-indicator'></span>
                                <div class='slick-resizable-handle'></div>
                            </div>
                            <div class='ui-state-default slick-header-column' id='slickgrid_185921ITEM' title='ITEM' style='width: 243px;'>
                                <span class='slick-column-name'>ITEM</span>
                                <span class='slick-sort-indicator'></span>
                                <div class='slick-resizable-handle'></div>
                            </div>
                            <div class='ui-state-default slick-header-column' id='slickgrid_185921D E T A L L E' title='D E T A L L E'
                                style='width: 244px;'>
                                <span class='slick-column-name'>D E T A L L E</span>
                                <span class='slick-sort-indicator'></span>
                                <div class='slick-resizable-handle'></div>
                            </div>
                            <div class='ui-state-default slick-header-column' id='slickgrid_185921UNIDAD' title='UNIDAD'
                                style='width: 244px;'>
                                <span class='slick-column-name'>UNIDAD</span>
                                <span class='slick-sort-indicator'></span>
                                <div class='slick-resizable-handle'></div>
                            </div>
                            <div class='ui-state-default slick-header-column' id='slickgrid_185921V A L O R' title='V A L O R'
                                style='width: 244px;'>
                                <span class='slick-column-name'>V A L O R</span>
                                <span class='slick-sort-indicator'></span>
                            </div>
                        </div>
                    </div>
                    <div class='slick-headerrow ui-state-default' style='overflow: hidden; position: relative; display: none;'>
                        <div class='slick-headerrow-columns' style='width: 1263px;'></div>
                    </div>
                    <div class='slick-top-panel-scroller ui-state-default' style='overflow: hidden; position: relative; display: none;'>
                        <div class='slick-top-panel' style='width:10000px'></div>
                    </div>
                    <div class='slick-viewport' style='width: 100%; overflow: auto; outline: 0px; position: relative; height: 574px;'>
                        <div class='grid-canvas' style='width: 1263px; height: 875px;'>
                            <div class='ui-widget-content slick-row  even' row='0' style='top:0px'>
                                <div class='slick-cell l0 r0'>1</div>
                                <div class='slick-cell l1 r1'>1</div>
                                <div class='slick-cell l2 r2'>Índice de precios al consumidor (1)</div>
                                <div class='slick-cell l3 r3'>-</div>
                                <div class='slick-cell l4 r4'>116.29</div>
                            </div>
                            <div class='ui-widget-content slick-row  odd' row='1' style='top:25px'>
                                <div class='slick-cell l0 r0'>2</div>
                                <div class='slick-cell l1 r1'>2</div>
                                <div class='slick-cell l2 r2'>Índice de remuneraciones (2)</div>
                                <div class='slick-cell l3 r3'>-</div>
                                <div class='slick-cell l4 r4'>3923.78</div>
                            </div>
                            <div class='ui-widget-content slick-row  even' row='2' style='top:50px'>
                                <div class='slick-cell l0 r0'>3</div>
                                <div class='slick-cell l1 r1'>Precios (3)</div>
                                <div class='slick-cell l2 r2'></div>
                                <div class='slick-cell l3 r3'></div>
                                <div class='slick-cell l4 r4'></div>
                            </div>
                            <div class='ui-widget-content slick-row  odd' row='3' style='top:75px'>
                                <div class='slick-cell l0 r0'>4</div>
                                <div class='slick-cell l1 r1'>ITEM</div>
                                <div class='slick-cell l2 r2'>D E T A L L E</div>
                                <div class='slick-cell l3 r3'>UNIDAD</div>
                                <div class='slick-cell l4 r4'>VALOR ($)</div>
                            </div>
                            <div class='ui-widget-content slick-row  even' row='4' style='top:100px'>
                                <div class='slick-cell l0 r0'>5</div>
                                <div class='slick-cell l1 r1'>3</div>
                                <div class='slick-cell l2 r2'>Petróleo Diesel (4)</div>
                                <div class='slick-cell l3 r3'>m3</div>
                                <div class='slick-cell l4 r4'>414275.097727</div>
                            </div>
                            <div class='ui-widget-content slick-row  odd' row='5' style='top:125px'>
                                <div class='slick-cell l0 r0'>6</div>
                                <div class='slick-cell l1 r1'>22</div>
                                <div class='slick-cell l2 r2'>Dólar observado</div>
                                <div class='slick-cell l3 r3'>$/US$</div>
                                <div class='slick-cell l4 r4'>642.41</div>
                            </div>
                            <div class='ui-widget-content slick-row  even' row='6' style='top:150px'>
                                <div class='slick-cell l0 r0'>7</div>
                                <div class='slick-cell l1 r1'>24</div>
                                <div class='slick-cell l2 r2'>Tubería PVC Ø 75 mm clase 10 (con unión)</div>
                                <div class='slick-cell l3 r3'>m</div>
                                <div class='slick-cell l4 r4'>2857.0</div>
                            </div>
                            <div class='ui-widget-content slick-row  odd' row='7' style='top:175px'>
                                <div class='slick-cell l0 r0'>8</div>
                                <div class='slick-cell l1 r1'>25</div>
                                <div class='slick-cell l2 r2'>Tubería PVC Ø 110 mm clase 10 (con unión)</div>
                                <div class='slick-cell l3 r3'>m</div>
                                <div class='slick-cell l4 r4'>4955.0</div>
                            </div>
                            <div class='ui-widget-content slick-row  even' row='8' style='top:200px'>
                                <div class='slick-cell l0 r0'>9</div>
                                <div class='slick-cell l1 r1'>27</div>
                                <div class='slick-cell l2 r2'>Petróleo Diesel de refinería CONCÓN</div>
                                <div class='slick-cell l3 r3'>m3</div>
                                <div class='slick-cell l4 r4'>326827.0</div>
                            </div>
                            <div class='ui-widget-content slick-row  odd' row='9' style='top:225px'>
                                <div class='slick-cell l0 r0'>10</div>
                                <div class='slick-cell l1 r1'>28</div>
                                <div class='slick-cell l2 r2'>Alambre Cu 12 - AWG 3.31 mm2</div>
                                <div class='slick-cell l3 r3'>kg</div>
                                <div class='slick-cell l4 r4'>7710.0</div>
                            </div>
                            <div class='ui-widget-content slick-row  even' row='10' style='top:250px'>
                                <div class='slick-cell l0 r0'>11</div>
                                <div class='slick-cell l1 r1'></div>
                                <div class='slick-cell l2 r2'></div>
                                <div class='slick-cell l3 r3'></div>
                                <div class='slick-cell l4 r4'></div>
                            </div>
                            <div class='ui-widget-content slick-row  odd' row='11' style='top:275px'>
                                <div class='slick-cell l0 r0'>12</div>
                                <div class='slick-cell l1 r1'>Indices IPP de Industria manufacturera (base 2014=100) (5)</div>
                                <div class='slick-cell l2 r2'></div>
                                <div class='slick-cell l3 r3'></div>
                                <div class='slick-cell l4 r4'></div>
                            </div>
                            <div class='ui-widget-content slick-row  even' row='12' style='top:300px'>
                                <div class='slick-cell l0 r0'>13</div>
                                <div class='slick-cell l1 r1'>ITEM</div>
                                <div class='slick-cell l2 r2'>D E T A L L E</div>
                                <div class='slick-cell l3 r3'>UNIDAD</div>
                                <div class='slick-cell l4 r4'>VALOR</div>
                            </div>
                            <div class='ui-widget-content slick-row  odd' row='13' style='top:325px'>
                                <div class='slick-cell l0 r0'>14</div>
                                <div class='slick-cell l1 r1'>36.0</div>
                                <div class='slick-cell l2 r2'>Madera de coníferas o de especies no coníferas cepilladas, machimbrada, rebajada o tinglada,
                                    sin impregnar</div>
                                <div class='slick-cell l3 r3'>-</div>
                                <div class='slick-cell l4 r4'>105.62</div>
                            </div>
                            <div class='ui-widget-content slick-row  even' row='14' style='top:350px'>
                                <div class='slick-cell l0 r0'>15</div>
                                <div class='slick-cell l1 r1'>37.0</div>
                                <div class='slick-cell l2 r2'>Barnices y otras pinturas n.c.p. y Pinturas (6)</div>
                                <div class='slick-cell l3 r3'>-</div>
                                <div class='slick-cell l4 r4'>103.88</div>
                            </div>
                            <div class='ui-widget-content slick-row  odd' row='15' style='top:375px'>
                                <div class='slick-cell l0 r0'>16</div>
                                <div class='slick-cell l1 r1'>38.0</div>
                                <div class='slick-cell l2 r2'>Vidrio templado y vidrio pulido o pulimentado, en planchas</div>
                                <div class='slick-cell l3 r3'>-</div>
                                <div class='slick-cell l4 r4'>111.54</div>
                            </div>
                            <div class='ui-widget-content slick-row  even' row='16' style='top:400px'>
                                <div class='slick-cell l0 r0'>17</div>
                                <div class='slick-cell l1 r1'>39.0</div>
                                <div class='slick-cell l2 r2'>Cemento; excluye refractarios</div>
                                <div class='slick-cell l3 r3'>-</div>
                                <div class='slick-cell l4 r4'>116.98</div>
                            </div>
                            <div class='ui-widget-content slick-row  odd' row='17' style='top:425px'>
                                <div class='slick-cell l0 r0'>18</div>
                                <div class='slick-cell l1 r1'>40.0</div>
                                <div class='slick-cell l2 r2'>Mezclas bituminosas </div>
                                <div class='slick-cell l3 r3'>-</div>
                                <div class='slick-cell l4 r4'>85.89</div>
                            </div>
                            <div class='ui-widget-content slick-row  even' row='18' style='top:450px'>
                                <div class='slick-cell l0 r0'>19</div>
                                <div class='slick-cell l1 r1'>41.0</div>
                                <div class='slick-cell l2 r2'>Manufacturas de hierro o acero no aleado</div>
                                <div class='slick-cell l3 r3'>-</div>
                                <div class='slick-cell l4 r4'>100.58</div>
                            </div>
                            <div class='ui-widget-content slick-row  odd' row='19' style='top:475px'>
                                <div class='slick-cell l0 r0'>20</div>
                                <div class='slick-cell l1 r1'>42.0</div>
                                <div class='slick-cell l2 r2'>Fabricación de otros productos químicos n.c.p.</div>
                                <div class='slick-cell l3 r3'>-</div>
                                <div class='slick-cell l4 r4'>113.23</div>
                            </div>
                            <div class='ui-widget-content slick-row  even' row='20' style='top:500px'>
                                <div class='slick-cell l0 r0'>21</div>
                                <div class='slick-cell l1 r1'></div>
                                <div class='slick-cell l2 r2'></div>
                                <div class='slick-cell l3 r3'></div>
                                <div class='slick-cell l4 r4'></div>
                            </div>
                            <div class='ui-widget-content slick-row  odd' row='21' style='top:525px'>
                                <div class='slick-cell l0 r0'>22</div>
                                <div class='slick-cell l1 r1'>Notas:</div>
                                <div class='slick-cell l2 r2'> </div>
                                <div class='slick-cell l3 r3'></div>
                                <div class='slick-cell l4 r4'></div>
                            </div>
                            <div class='ui-widget-content slick-row  even' row='22' style='top:550px'>
                                <div class='slick-cell l0 r0'>23</div>
                                <div class='slick-cell l1 r1'>(1)</div>
                                <div class='slick-cell l2 r2'>Índice de Precio al Consumidor: Base Anual 2013 = 100. El INE cambió la base del IPC de 2009=100
                                    a 2013 = 100 a partir de enero de 2014. Para calcular el reajuste a partir delnuevo índice,
                                    debe utilizarse la publicación del INE: 'Empalme de las Series del IPC, factor de reajustabilidad',
                                    en la sección 'Antecedentes Metodológicos' de la dirección web siguiente:</div>
                                <div class='slick-cell l3 r3'></div>
                                <div class='slick-cell l4 r4'></div>
                            </div>
                            <div class='ui-widget-content slick-row  odd' row='23' style='top:575px'>
                                <div class='slick-cell l0 r0'>24</div>
                                <div class='slick-cell l1 r1'></div>
                                <div class='slick-cell l2 r2'>
                                    <a href='http://www.ine.cl/canales/chile_estadistico/estadisticas_precios/ipc/base_2013/index.php'>http://www.ine.cl/canales/chile_estadistico/estadisticas_precios/ipc/base_2013/index.php</a>
                                </div>
                                <div class='slick-cell l3 r3'></div>
                                <div class='slick-cell l4 r4'></div>
                            </div>
                            <div class='ui-widget-content slick-row  even' row='24' style='top:600px'>
                                <div class='slick-cell l0 r0'>25</div>
                                <div class='slick-cell l1 r1'>(2)</div>
                                <div class='slick-cell l2 r2'>El índice de remuneraciones se calcula multiplicando el Indice de Remuneraciones del mes
                                    anterior por el factor resultante de la división del Índice Nominal del Costo de la Mano
                                    de Obra por hora (ICMO) de 2 meses atrás por el ICMO de 3 meses atrás (ambos ICMO de
                                    BasesAnual 2009=100), aplicado con 15 decimales truncado (RES. DP. EXENTA N°218 de 2010).</div>
                                <div
                                    class='slick-cell l3 r3'></div>
                            <div class='slick-cell l4 r4'></div>
                        </div>
                        <div class='ui-widget-content slick-row  odd' row='25' style='top:625px'>
                            <div class='slick-cell l0 r0'>26</div>
                            <div class='slick-cell l1 r1'>(3)</div>
                            <div class='slick-cell l2 r2'>Para los antiguos ítem del 4 al 21 (IPM), se deberán utilizar sus equivalentes (IPP) según Resoluciones
                                exentas N° 010 del 14-01-2014 y N° 361 del 28-04-2017 de la Dirección de Planeamiento </div>
                            <div
                                class='slick-cell l3 r3'></div>
                        <div class='slick-cell l4 r4'></div>
                    </div>
                    <div class='ui-widget-content slick-row  even' row='26' style='top:650px'>
                        <div class='slick-cell l0 r0'>27</div>
                        <div class='slick-cell l1 r1'>(4)</div>
                        <div class='slick-cell l2 r2'>El valor del petróleo Diesel (Item 3) incluye el impuesto específico. Se calcula multiplicando el
                            valor de Diciembre de 2011 (sin impuesto específico) por la variación entre Diciembre de 2011
                            y el mes informado, del petróleo Diesel de refinería de Concón (item 27) y sumándole el impuesto
                            específico (Resol DP 140 de 03-04-2014). El Petróleo Diesel de Refinería de Concón (Item 27)
                            no incluye impuesto específico. Impuesto Específico Petróleo Diesel = 1.5 UTM/m3.</div>
                        <div class='slick-cell l3 r3'></div>
                        <div class='slick-cell l4 r4'></div>
                    </div>
                    <div class='ui-widget-content slick-row  odd' row='27' style='top:675px'>
                        <div class='slick-cell l0 r0'>28</div>
                        <div class='slick-cell l1 r1'>(5)</div>
                        <div class='slick-cell l2 r2'>Los Valores de índices IPP se publican sólo despues de ser publicados por el INE, aproximadamente
                            los días 24 de cada mes.</div>
                        <div class='slick-cell l3 r3'></div>
                        <div class='slick-cell l4 r4'></div>
                    </div>
                    <div class='ui-widget-content slick-row  even' row='28' style='top:700px'>
                        <div class='slick-cell l0 r0'>29</div>
                        <div class='slick-cell l1 r1'>(6)</div>
                        <div class='slick-cell l2 r2'>Valores productos INE 3511003 y 3511009 ponderados por 0,06257 y 0,93743 respectivamente</div>
                        <div
                            class='slick-cell l3 r3'></div>
                    <div class='slick-cell l4 r4'></div>
                </div>
                <div class='ui-widget-content slick-row  odd' row='29' style='top:725px'>
                    <div class='slick-cell l0 r0'>30</div>
                    <div class='slick-cell l1 r1'></div>
                    <div class='slick-cell l2 r2'></div>
                    <div class='slick-cell l3 r3'></div>
                    <div class='slick-cell l4 r4'></div>
                </div>
                <div class='ui-widget-content slick-row  even' row='30' style='top:750px'>
                    <div class='slick-cell l0 r0'>31</div>
                    <div class='slick-cell l1 r1'></div>
                    <div class='slick-cell l2 r2'>Valor UF al último día del mes informado = </div>
                    <div class='slick-cell l3 r3'>26731.12</div>
                    <div class='slick-cell l4 r4'></div>
                </div>
                <div class='ui-widget-content slick-row  odd' row='31' style='top:775px'>
                    <div class='slick-cell l0 r0'>32</div>
                    <div class='slick-cell l1 r1'></div>
                    <div class='slick-cell l2 r2'>Valor UTM mes informado</div>
                    <div class='slick-cell l3 r3'>46692.0</div>
                    <div class='slick-cell l4 r4'></div>
                </div>
                <div class='ui-widget-content slick-row  even' row='32' style='top:800px'>
                    <div class='slick-cell l0 r0'>33</div>
                    <div class='slick-cell l1 r1'>Fuentes:</div>
                    <div class='slick-cell l2 r2'>1 , 2 y 36 al 42: INE </div>
                    <div class='slick-cell l3 r3'>22 : BANCO CENTRAL </div>
                    <div class='slick-cell l4 r4'></div>
                </div>
                <div class='ui-widget-content slick-row  odd' row='33' style='top:825px'>
                    <div class='slick-cell l0 r0'>34</div>
                    <div class='slick-cell l1 r1'></div>
                    <div class='slick-cell l2 r2'>24-25 : DURATEC-VINILIT </div>
                    <div class='slick-cell l3 r3'> 27 : ENAP</div>
                    <div class='slick-cell l4 r4'></div>
                </div>
                <div class='ui-widget-content slick-row  even' row='34' style='top:850px'>
                    <div class='slick-cell l0 r0'>35</div>
                    <div class='slick-cell l1 r1'></div>
                    <div class='slick-cell l2 r2'>28 : NEXANS (MADECO)</div>
                    <div class='slick-cell l3 r3'></div>
                    <div class='slick-cell l4 r4'></div>
                </div>
            </div>
        </div>
    </div>
    <div style='display: none;'>
        <div class='recline-flot'>
            <div class='panel graph' style='display: block;'>
                <div class='js-temp-notice alert alert-block'>
                    <h3 class='alert-heading'>Hey there!</h3>
                    <p>There's no graph here yet because we don't know what fields you'd like to see plotted.</p>
                    <p>Please tell us by
                        <strong>using the menu on the right</strong> and a graph will automatically appear.</p>
                </div>
            </div>
        </div>
    </div>
    <div style='display: none;'>
        <div class='recline-map'>
            <div class='panel map leaflet-container leaflet-touch leaflet-fade-anim' tabindex='0' style='position: relative;'>
                <div class='leaflet-map-pane' style='-webkit-transform: translate3d(0px, 0px, 0);'>
                    <div class='leaflet-tile-pane'>
                        <div class='leaflet-layer'>
                            <div class='leaflet-tile-container'></div>
                            <div class='leaflet-tile-container'>
                                <img class='leaflet-tile' src='//tile.thunderforest.com/neighbourhood/2/2/2.png' style='height: 256px; width: 256px; left: 0px; top: 0px;'>
                            </div>
                        </div>
                    </div>
                    <div class='leaflet-objects-pane'>
                        <div class='leaflet-shadow-pane'></div>
                        <div class='leaflet-overlay-pane'></div>
                        <div class='leaflet-marker-pane'></div>
                        <div class='leaflet-popup-pane'></div>
                    </div>
                </div>
                <div class='leaflet-control-container'>
                    <div class='leaflet-top leaflet-left'>
                        <div class='leaflet-control-zoom leaflet-bar leaflet-control'>
                            <a class='leaflet-control-zoom-in' href='#' title='Zoom in'>+</a>
                            <a class='leaflet-control-zoom-out' href='#' title='Zoom out'>-</a>
                        </div>
                    </div>
                    <div class='leaflet-top leaflet-right'></div>
                    <div class='leaflet-bottom leaflet-left'></div>
                    <div class='leaflet-bottom leaflet-right'>
                        <div class='leaflet-control-attribution leaflet-control'>
                            <a href='http://leafletjs.com' title='A JS library for interactive maps'>Leaflet</a> | Maps ©
                            <a href='http://www.thunderforest.com'>Thunderforest</a>, Data ©
                            <a href='http://www.openstreetmap.org/copyright'>OpenStreetMap contributors</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
    </div>
    </div>






    <script>document.getElementsByTagName('html')[0].className += ' js';</script>
    <script type='text/javascript' src='/fanstatic/vendor/:version:2016-03-08T17:24:20.94/jquery.min.js'></script>
    <script type='text/javascript' src='/fanstatic/vendor/:version:2016-03-08T17:24:20.94/:bundle:jed.min.js;select2/select2.min.js'></script>
    <script type='text/javascript' src='/fanstatic/base/:version:2016-03-08T17:24:21.76/:bundle:plugins/jquery.inherit.min.js;plugins/jquery.proxy-all.min.js;plugins/jquery.url-helpers.min.js;plugins/jquery.date-helpers.min.js;plugins/jquery.slug.min.js;plugins/jquery.slug-preview.min.js;plugins/jquery.truncator.min.js;plugins/jquery.masonry.min.js;plugins/jquery.form-warning.min.js;sandbox.min.js;module.min.js;pubsub.min.js;client.min.js;notify.min.js;i18n.min.js;main.min.js'></script>
    <script type='text/javascript' src='/fanstatic/ckanext-reclineview/:version:2016-09-01T16:21:30.10/:bundle:vendor/jquery/1.7.1/jquery.min.js;vendor/underscore/1.4.4/underscore.js;vendor/backbone/1.0.0/backbone.js;vendor/mustache/0.5.0-dev/mustache.min.js;vendor/bootstrap/2.3.2/bootstrap.js'></script>
    <!--[if lte ie 7]><script type='text/javascript' src='/fanstatic/ckanext-reclineview/:version:2016-09-01T16:21:30.10/vendor/json/json2.min.js'></script><![endif]-->
    <!--[if lte ie 8]><script type='text/javascript' src='/fanstatic/ckanext-reclineview/:version:2016-09-01T16:21:30.10/vendor/flot/excanvas.min.js'></script><![endif]-->
    <script type='text/javascript' src='/fanstatic/ckanext-reclineview/:version:2016-09-01T16:21:30.10/:bundle:vendor/flot/jquery.flot.js;vendor/flot/jquery.flot.time.js;vendor/leaflet/0.7.3/leaflet.js;vendor/leaflet.markercluster/leaflet.markercluster.js;vendor/slickgrid/2.0.1/jquery-ui-1.8.16.custom.min.js;vendor/slickgrid/2.0.1/jquery.event.drag-2.0.min.js;vendor/slickgrid/2.0.1/slick.grid.min.js;vendor/slickgrid/2.0.1/plugins/slick.rowselectionmodel.js;vendor/slickgrid/2.0.1/plugins/slick.rowmovemanager.js;vendor/moment/2.0.0/moment.js;vendor/ckan.js/ckan.js;vendor/recline/recline.js;widget.recordcount.min.js;recline_view.min.js'></script>
    <script type='text/javascript' src='/fanstatic/egobcl_theme/:version:2016-03-08T17:27:40.60/:bundle:script.js;jquery.Rut.js'></script>
    <ul class='dropdown-menu slick-contextmenu' style='display:none;position:absolute;z-index:20;'></ul>
</body>
</html>";
        }
    }
}
