<%@ Page Title="" Language="vb"  EnableEventValidation="false" AutoEventWireup="true" MasterPageFile="~/main.Master" CodeBehind="modifica_impianto_form.aspx.vb" Inherits="ermes_web_20.modifica_setpoint_form" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ MasterType VirtualPath="~/main.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="principale_alert" style="z-index:10000; position:absolute" >
    </div>

    <div id="content">
        <h3 class="heading-mosaic"><asp:Literal ID="Literal1" runat="server" Text="Modifica Impianto" meta:resourcekey="Literal1Resource1"></asp:Literal></h3>
        <div class="innerAll">
            <div class="widget">
                <div class="widget-body">
                    <div class="row-fluid">
                        <!-- gruppo-->
							<div class="span3">
								<strong><asp:Literal ID="Literal7" runat="server" Text="Dati impianto" meta:resourcekey="Literal7Resource1"></asp:Literal> </strong>
								<p class="muted"><asp:Literal ID="Literal8" runat="server" Text="Modifica i i dati relativi all'impianto" meta:resourcekey="Literal8Resource1"></asp:Literal></p>
							</div>
							<div class="span9">
                                <!--
                                <p><asp:Literal ID="Literal9" runat="server" Text="Nome" ></asp:Literal></p>
								<asp:TextBox ID="inputNome" class="span6" placeholder="Inserisci il nome ..." runat="server"></asp:TextBox>
                                    -->
								<div class="separator"></div>
                                <p><asp:Literal ID="Literal10" runat="server" Text="Codice" meta:resourcekey="Literal10Resource1"></asp:Literal></p>
                                <asp:TextBox ID="inputCodice" ClientIDMode="Static" onblur="javascript: Changed_channel( 'inputCodice',6);" class="span6" placeholder="" runat="server" MaxLength="6" ReadOnly="True" meta:resourcekey="inputCodiceResource1"></asp:TextBox>
                                								
                                <div class="separator"></div>
                             	<p><asp:Literal ID="Literal11" runat="server" Text="Descrizione" meta:resourcekey="Literal11Resource1"></asp:Literal></p>
                                <asp:TextBox ID="textDescription" ClientIDMode="Static"  style="width: 96%;" rows="5"  placeholder="" runat="server" TextMode="MultiLine" meta:resourcekey="textDescriptionResource1"></asp:TextBox>
                                
							</div>
                        </div>
                    <!-- end gruppo-->
<!-- gruppo-->
                        <div class="row-fluid">
							<div class="span3">
								<strong><asp:Literal ID="Literal12" runat="server" Text="Modifica Indirizzo impianto" meta:resourcekey="Literal12Resource1"></asp:Literal></strong>
								<p class="muted"><asp:Literal ID="Literal13" runat="server" Text="Inserisci un indirizzo valido" meta:resourcekey="Literal13Resource1"></asp:Literal></p>
							</div>
							<div class="span9">
                            
                                    <!--
                                    <asp:ListItem Value="IT-Italy-Roma-Roma-via arice, 1">Italy - Roma - Roma- via arice, 1</asp:ListItem>
                                    <asp:ListItem Value="IT-Italy-Roma--via arice, ">Italy - Roma - via arice </asp:ListItem>
                                     -->
                                
                                <div class="separator"></div>
                                <p><asp:Literal ID="Literal16" runat="server" Text="Nazione" meta:resourcekey="Literal16Resource1"></asp:Literal></p>
							
								
                                    <asp:DropDownList ClientIDMode="Static" ID="countries" runat="server" meta:resourcekey="countriesResource1">
<asp:ListItem value="empty">Empty</asp:ListItem>
<asp:ListItem value="AF" meta:resourcekey="ListItemResource1">Afghanistan</asp:ListItem>
<asp:ListItem value="AX" meta:resourcekey="ListItemResource2">Åland Islands</asp:ListItem>
<asp:ListItem value="AL" meta:resourcekey="ListItemResource3">Albania</asp:ListItem>
<asp:ListItem value="DZ" meta:resourcekey="ListItemResource4">Algeria</asp:ListItem>
<asp:ListItem value="AS" meta:resourcekey="ListItemResource5">American Samoa</asp:ListItem>
<asp:ListItem value="AD" meta:resourcekey="ListItemResource6">Andorra</asp:ListItem>
<asp:ListItem value="AO" meta:resourcekey="ListItemResource7">Angola</asp:ListItem>
<asp:ListItem value="AI" meta:resourcekey="ListItemResource8">Anguilla</asp:ListItem>
<asp:ListItem value="AQ" meta:resourcekey="ListItemResource9">Antarctica</asp:ListItem>
<asp:ListItem value="AG" meta:resourcekey="ListItemResource10">Antigua and Barbuda</asp:ListItem>
<asp:ListItem value="AR" meta:resourcekey="ListItemResource11">Argentina</asp:ListItem>
<asp:ListItem value="AM" meta:resourcekey="ListItemResource12">Armenia</asp:ListItem>
<asp:ListItem value="AW" meta:resourcekey="ListItemResource13">Aruba</asp:ListItem>
<asp:ListItem value="AU" meta:resourcekey="ListItemResource14">Australia</asp:ListItem>
<asp:ListItem value="AT" meta:resourcekey="ListItemResource15">Austria</asp:ListItem>
<asp:ListItem value="AZ" meta:resourcekey="ListItemResource16">Azerbaijan</asp:ListItem>
<asp:ListItem value="BS" meta:resourcekey="ListItemResource17">Bahamas</asp:ListItem>
<asp:ListItem value="BH" meta:resourcekey="ListItemResource18">Bahrain</asp:ListItem>
<asp:ListItem value="BD" meta:resourcekey="ListItemResource19">Bangladesh</asp:ListItem>
<asp:ListItem value="BB" meta:resourcekey="ListItemResource20">Barbados</asp:ListItem>
<asp:ListItem value="BY" meta:resourcekey="ListItemResource21">Belarus</asp:ListItem>
<asp:ListItem value="BE" meta:resourcekey="ListItemResource22">Belgium</asp:ListItem>
<asp:ListItem value="BZ" meta:resourcekey="ListItemResource23">Belize</asp:ListItem>
<asp:ListItem value="BJ" meta:resourcekey="ListItemResource24">Benin</asp:ListItem>
<asp:ListItem value="BM" meta:resourcekey="ListItemResource25">Bermuda</asp:ListItem>
<asp:ListItem value="BT" meta:resourcekey="ListItemResource26">Bhutan</asp:ListItem>
<asp:ListItem value="BO" meta:resourcekey="ListItemResource27">Bolivia</asp:ListItem>
<asp:ListItem value="BA" meta:resourcekey="ListItemResource28">Bosnia and Herzegovina</asp:ListItem>
<asp:ListItem value="BW" meta:resourcekey="ListItemResource29">Botswana</asp:ListItem>
<asp:ListItem value="BV" meta:resourcekey="ListItemResource30">Bouvet Island</asp:ListItem>
<asp:ListItem value="BR" meta:resourcekey="ListItemResource31">Brazil</asp:ListItem>
<asp:ListItem value="IO" meta:resourcekey="ListItemResource32">British Indian Ocean Territory</asp:ListItem>
<asp:ListItem value="BN" meta:resourcekey="ListItemResource33">Brunei Darussalam</asp:ListItem>
<asp:ListItem value="BG" meta:resourcekey="ListItemResource34">Bulgaria</asp:ListItem>
<asp:ListItem value="BF" meta:resourcekey="ListItemResource35">Burkina Faso</asp:ListItem>
<asp:ListItem value="BI" meta:resourcekey="ListItemResource36">Burundi</asp:ListItem>
<asp:ListItem value="KH" meta:resourcekey="ListItemResource37">Cambodia</asp:ListItem>
<asp:ListItem value="CM" meta:resourcekey="ListItemResource38">Cameroon</asp:ListItem>
<asp:ListItem value="CA" meta:resourcekey="ListItemResource39">Canada</asp:ListItem>
<asp:ListItem value="CV" meta:resourcekey="ListItemResource40">Cape Verde</asp:ListItem>
<asp:ListItem value="KY" meta:resourcekey="ListItemResource41">Cayman Islands</asp:ListItem>
<asp:ListItem value="CF" meta:resourcekey="ListItemResource42">Central African Republic</asp:ListItem>
<asp:ListItem value="TD" meta:resourcekey="ListItemResource43">Chad</asp:ListItem>
<asp:ListItem value="CL" meta:resourcekey="ListItemResource44">Chile</asp:ListItem>
<asp:ListItem value="CN" meta:resourcekey="ListItemResource45">China</asp:ListItem>
<asp:ListItem value="CX" meta:resourcekey="ListItemResource46">Christmas Island</asp:ListItem>
<asp:ListItem value="CC" meta:resourcekey="ListItemResource47">Cocos (Keeling) Islands</asp:ListItem>
<asp:ListItem value="CO" meta:resourcekey="ListItemResource48">Colombia</asp:ListItem>
<asp:ListItem value="KM" meta:resourcekey="ListItemResource49">Comoros</asp:ListItem>
<asp:ListItem value="CG" meta:resourcekey="ListItemResource50">Congo</asp:ListItem>
<asp:ListItem value="CD" meta:resourcekey="ListItemResource51">Congo, The Democratic Republic of The</asp:ListItem>
<asp:ListItem value="CK" meta:resourcekey="ListItemResource52">Cook Islands</asp:ListItem>
<asp:ListItem value="CR" meta:resourcekey="ListItemResource53">Costa Rica</asp:ListItem>
<asp:ListItem value="CI" meta:resourcekey="ListItemResource54">Cote D'ivoire</asp:ListItem>
<asp:ListItem value="HR" meta:resourcekey="ListItemResource55">Croatia</asp:ListItem>
<asp:ListItem value="CU" meta:resourcekey="ListItemResource56">Cuba</asp:ListItem>
<asp:ListItem value="CY" meta:resourcekey="ListItemResource57">Cyprus</asp:ListItem>
<asp:ListItem value="CZ" meta:resourcekey="ListItemResource58">Czech Republic</asp:ListItem>
<asp:ListItem value="DK" meta:resourcekey="ListItemResource59">Denmark</asp:ListItem>
<asp:ListItem value="DJ" meta:resourcekey="ListItemResource60">Djibouti</asp:ListItem>
<asp:ListItem value="DM" meta:resourcekey="ListItemResource61">Dominica</asp:ListItem>
<asp:ListItem value="DO" meta:resourcekey="ListItemResource62">Dominican Republic</asp:ListItem>
<asp:ListItem value="EC" meta:resourcekey="ListItemResource63">Ecuador</asp:ListItem>
<asp:ListItem value="EG" meta:resourcekey="ListItemResource64">Egypt</asp:ListItem>
<asp:ListItem value="SV" meta:resourcekey="ListItemResource65">El Salvador</asp:ListItem>
<asp:ListItem value="GQ" meta:resourcekey="ListItemResource66">Equatorial Guinea</asp:ListItem>
<asp:ListItem value="ER" meta:resourcekey="ListItemResource67">Eritrea</asp:ListItem>
<asp:ListItem value="EE" meta:resourcekey="ListItemResource68">Estonia</asp:ListItem>
<asp:ListItem value="ET" meta:resourcekey="ListItemResource69">Ethiopia</asp:ListItem>
<asp:ListItem value="FK" meta:resourcekey="ListItemResource70">Falkland Islands (Malvinas)</asp:ListItem>
<asp:ListItem value="FO" meta:resourcekey="ListItemResource71">Faroe Islands</asp:ListItem>
<asp:ListItem value="FJ" meta:resourcekey="ListItemResource72">Fiji</asp:ListItem>
<asp:ListItem value="FI" meta:resourcekey="ListItemResource73">Finland</asp:ListItem>
<asp:ListItem value="FR" meta:resourcekey="ListItemResource74">France</asp:ListItem>
<asp:ListItem value="GF" meta:resourcekey="ListItemResource75">French Guiana</asp:ListItem>
<asp:ListItem value="PF" meta:resourcekey="ListItemResource76">French Polynesia</asp:ListItem>
<asp:ListItem value="TF" meta:resourcekey="ListItemResource77">French Southern Territories</asp:ListItem>
<asp:ListItem value="GA" meta:resourcekey="ListItemResource78">Gabon</asp:ListItem>
<asp:ListItem value="GM" meta:resourcekey="ListItemResource79">Gambia</asp:ListItem>
<asp:ListItem value="GE" meta:resourcekey="ListItemResource80">Georgia</asp:ListItem>
<asp:ListItem value="DE" meta:resourcekey="ListItemResource81">Germany</asp:ListItem>
<asp:ListItem value="GH" meta:resourcekey="ListItemResource82">Ghana</asp:ListItem>
<asp:ListItem value="GI" meta:resourcekey="ListItemResource83">Gibraltar</asp:ListItem>
<asp:ListItem value="GR" meta:resourcekey="ListItemResource84">Greece</asp:ListItem>
<asp:ListItem value="GL" meta:resourcekey="ListItemResource85">Greenland</asp:ListItem>
<asp:ListItem value="GD" meta:resourcekey="ListItemResource86">Grenada</asp:ListItem>
<asp:ListItem value="GP" meta:resourcekey="ListItemResource87">Guadeloupe</asp:ListItem>
<asp:ListItem value="GU" meta:resourcekey="ListItemResource88">Guam</asp:ListItem>
<asp:ListItem value="GT" meta:resourcekey="ListItemResource89">Guatemala</asp:ListItem>
<asp:ListItem value="GG" meta:resourcekey="ListItemResource90">Guernsey</asp:ListItem>
<asp:ListItem value="GN" meta:resourcekey="ListItemResource91">Guinea</asp:ListItem>
<asp:ListItem value="GW" meta:resourcekey="ListItemResource92">Guinea-bissau</asp:ListItem>
<asp:ListItem value="GY" meta:resourcekey="ListItemResource93">Guyana</asp:ListItem>
<asp:ListItem value="HT" meta:resourcekey="ListItemResource94">Haiti</asp:ListItem>
<asp:ListItem value="HM" meta:resourcekey="ListItemResource95">Heard Island and Mcdonald Islands</asp:ListItem>
<asp:ListItem value="VA" meta:resourcekey="ListItemResource96">Holy See (Vatican City State)</asp:ListItem>
<asp:ListItem value="HN" meta:resourcekey="ListItemResource97">Honduras</asp:ListItem>
<asp:ListItem value="HK" meta:resourcekey="ListItemResource98">Hong Kong</asp:ListItem>
<asp:ListItem value="HU" meta:resourcekey="ListItemResource99">Hungary</asp:ListItem>
<asp:ListItem value="IS" meta:resourcekey="ListItemResource100">Iceland</asp:ListItem>
<asp:ListItem value="IN" meta:resourcekey="ListItemResource101">India</asp:ListItem>
<asp:ListItem value="ID" meta:resourcekey="ListItemResource102">Indonesia</asp:ListItem>
<asp:ListItem value="IR" meta:resourcekey="ListItemResource103">Iran, Islamic Republic of</asp:ListItem>
<asp:ListItem value="IQ" meta:resourcekey="ListItemResource104">Iraq</asp:ListItem>
<asp:ListItem value="IE" meta:resourcekey="ListItemResource105">Ireland</asp:ListItem>
<asp:ListItem value="IM" meta:resourcekey="ListItemResource106">Isle of Man</asp:ListItem>
<asp:ListItem value="IL" meta:resourcekey="ListItemResource107">Israel</asp:ListItem>
<asp:ListItem value="IT" meta:resourcekey="ListItemResource108">Italy</asp:ListItem>
<asp:ListItem value="JM" meta:resourcekey="ListItemResource109">Jamaica</asp:ListItem>
<asp:ListItem value="JP" meta:resourcekey="ListItemResource110">Japan</asp:ListItem>
<asp:ListItem value="JE" meta:resourcekey="ListItemResource111">Jersey</asp:ListItem>
<asp:ListItem value="JO" meta:resourcekey="ListItemResource112">Jordan</asp:ListItem>
<asp:ListItem value="KZ" meta:resourcekey="ListItemResource113">Kazakhstan</asp:ListItem>
<asp:ListItem value="KE" meta:resourcekey="ListItemResource114">Kenya</asp:ListItem>
<asp:ListItem value="KI" meta:resourcekey="ListItemResource115">Kiribati</asp:ListItem>
<asp:ListItem value="KP" meta:resourcekey="ListItemResource116">Korea, Democratic People's Republic of</asp:ListItem>
<asp:ListItem value="KR" meta:resourcekey="ListItemResource117">Korea, Republic of</asp:ListItem>
<asp:ListItem value="KW" meta:resourcekey="ListItemResource118">Kuwait</asp:ListItem>
<asp:ListItem value="KG" meta:resourcekey="ListItemResource119">Kyrgyzstan</asp:ListItem>
<asp:ListItem value="LA" meta:resourcekey="ListItemResource120">Lao People's Democratic Republic</asp:ListItem>
<asp:ListItem value="LV" meta:resourcekey="ListItemResource121">Latvia</asp:ListItem>
<asp:ListItem value="LB" meta:resourcekey="ListItemResource122">Lebanon</asp:ListItem>
<asp:ListItem value="LS" meta:resourcekey="ListItemResource123">Lesotho</asp:ListItem>
<asp:ListItem value="LR" meta:resourcekey="ListItemResource124">Liberia</asp:ListItem>
<asp:ListItem value="LY" meta:resourcekey="ListItemResource125">Libyan Arab Jamahiriya</asp:ListItem>
<asp:ListItem value="LI" meta:resourcekey="ListItemResource126">Liechtenstein</asp:ListItem>
<asp:ListItem value="LT" meta:resourcekey="ListItemResource127">Lithuania</asp:ListItem>
<asp:ListItem value="LU" meta:resourcekey="ListItemResource128">Luxembourg</asp:ListItem>
<asp:ListItem value="MO" meta:resourcekey="ListItemResource129">Macao</asp:ListItem>
<asp:ListItem value="MK" meta:resourcekey="ListItemResource130">Macedonia, The Former Yugoslav Republic of</asp:ListItem>
<asp:ListItem value="MG" meta:resourcekey="ListItemResource131">Madagascar</asp:ListItem>
<asp:ListItem value="MW" meta:resourcekey="ListItemResource132">Malawi</asp:ListItem>
<asp:ListItem value="MY" meta:resourcekey="ListItemResource133">Malaysia</asp:ListItem>
<asp:ListItem value="MV" meta:resourcekey="ListItemResource134">Maldives</asp:ListItem>
<asp:ListItem value="ML" meta:resourcekey="ListItemResource135">Mali</asp:ListItem>
<asp:ListItem value="MT" meta:resourcekey="ListItemResource136">Malta</asp:ListItem>
<asp:ListItem value="MH" meta:resourcekey="ListItemResource137">Marshall Islands</asp:ListItem>
<asp:ListItem value="MQ" meta:resourcekey="ListItemResource138">Martinique</asp:ListItem>
<asp:ListItem value="MR" meta:resourcekey="ListItemResource139">Mauritania</asp:ListItem>
<asp:ListItem value="MU" meta:resourcekey="ListItemResource140">Mauritius</asp:ListItem>
<asp:ListItem value="YT" meta:resourcekey="ListItemResource141">Mayotte</asp:ListItem>
<asp:ListItem value="MX" meta:resourcekey="ListItemResource142">Mexico</asp:ListItem>
<asp:ListItem value="FM" meta:resourcekey="ListItemResource143">Micronesia, Federated States of</asp:ListItem>
<asp:ListItem value="MD" meta:resourcekey="ListItemResource144">Moldova, Republic of</asp:ListItem>
<asp:ListItem value="MC" meta:resourcekey="ListItemResource145">Monaco</asp:ListItem>
<asp:ListItem value="MN" meta:resourcekey="ListItemResource146">Mongolia</asp:ListItem>
<asp:ListItem value="ME" meta:resourcekey="ListItemResource147">Montenegro</asp:ListItem>
<asp:ListItem value="MS" meta:resourcekey="ListItemResource148">Montserrat</asp:ListItem>
<asp:ListItem value="MA" meta:resourcekey="ListItemResource149">Morocco</asp:ListItem>
<asp:ListItem value="MZ" meta:resourcekey="ListItemResource150">Mozambique</asp:ListItem>
<asp:ListItem value="MM" meta:resourcekey="ListItemResource151">Myanmar</asp:ListItem>
<asp:ListItem value="NA" meta:resourcekey="ListItemResource152">Namibia</asp:ListItem>
<asp:ListItem value="NR" meta:resourcekey="ListItemResource153">Nauru</asp:ListItem>
<asp:ListItem value="NP" meta:resourcekey="ListItemResource154">Nepal</asp:ListItem>
<asp:ListItem value="NL" meta:resourcekey="ListItemResource155">Netherlands</asp:ListItem>
<asp:ListItem value="AN" meta:resourcekey="ListItemResource156">Netherlands Antilles</asp:ListItem>
<asp:ListItem value="NC" meta:resourcekey="ListItemResource157">New Caledonia</asp:ListItem>
<asp:ListItem value="NZ" meta:resourcekey="ListItemResource158">New Zealand</asp:ListItem>
<asp:ListItem value="NI" meta:resourcekey="ListItemResource159">Nicaragua</asp:ListItem>
<asp:ListItem value="NE" meta:resourcekey="ListItemResource160">Niger</asp:ListItem>
<asp:ListItem value="NG" meta:resourcekey="ListItemResource161">Nigeria</asp:ListItem>
<asp:ListItem value="NU" meta:resourcekey="ListItemResource162">Niue</asp:ListItem>
<asp:ListItem value="NF" meta:resourcekey="ListItemResource163">Norfolk Island</asp:ListItem>
<asp:ListItem value="MP" meta:resourcekey="ListItemResource164">Northern Mariana Islands</asp:ListItem>
<asp:ListItem value="NO" meta:resourcekey="ListItemResource165">Norway</asp:ListItem>
<asp:ListItem value="OM" meta:resourcekey="ListItemResource166">Oman</asp:ListItem>
<asp:ListItem value="PK" meta:resourcekey="ListItemResource167">Pakistan</asp:ListItem>
<asp:ListItem value="PW" meta:resourcekey="ListItemResource168">Palau</asp:ListItem>
<asp:ListItem value="PS" meta:resourcekey="ListItemResource169">Palestinian Territory, Occupied</asp:ListItem>
<asp:ListItem value="PA" meta:resourcekey="ListItemResource170">Panama</asp:ListItem>
<asp:ListItem value="PG" meta:resourcekey="ListItemResource171">Papua New Guinea</asp:ListItem>
<asp:ListItem value="PY" meta:resourcekey="ListItemResource172">Paraguay</asp:ListItem>
<asp:ListItem value="PE" meta:resourcekey="ListItemResource173">Peru</asp:ListItem>
<asp:ListItem value="PH" meta:resourcekey="ListItemResource174">Philippines</asp:ListItem>
<asp:ListItem value="PN" meta:resourcekey="ListItemResource175">Pitcairn</asp:ListItem>
<asp:ListItem value="PL" meta:resourcekey="ListItemResource176">Poland</asp:ListItem>
<asp:ListItem value="PT" meta:resourcekey="ListItemResource177">Portugal</asp:ListItem>
<asp:ListItem value="PR" meta:resourcekey="ListItemResource178">Puerto Rico</asp:ListItem>
<asp:ListItem value="QA" meta:resourcekey="ListItemResource179">Qatar</asp:ListItem>
<asp:ListItem value="RE" meta:resourcekey="ListItemResource180">Reunion</asp:ListItem>
<asp:ListItem value="RO" meta:resourcekey="ListItemResource181">Romania</asp:ListItem>
<asp:ListItem value="RU" meta:resourcekey="ListItemResource182">Russian Federation</asp:ListItem>
<asp:ListItem value="RW" meta:resourcekey="ListItemResource183">Rwanda</asp:ListItem>
<asp:ListItem value="SH" meta:resourcekey="ListItemResource184">Saint Helena</asp:ListItem>
<asp:ListItem value="KN" meta:resourcekey="ListItemResource185">Saint Kitts and Nevis</asp:ListItem>
<asp:ListItem value="LC" meta:resourcekey="ListItemResource186">Saint Lucia</asp:ListItem>
<asp:ListItem value="PM" meta:resourcekey="ListItemResource187">Saint Pierre and Miquelon</asp:ListItem>
<asp:ListItem value="VC" meta:resourcekey="ListItemResource188">Saint Vincent and The Grenadines</asp:ListItem>
<asp:ListItem value="WS" meta:resourcekey="ListItemResource189">Samoa</asp:ListItem>
<asp:ListItem value="SM" meta:resourcekey="ListItemResource190">San Marino</asp:ListItem>
<asp:ListItem value="ST" meta:resourcekey="ListItemResource191">Sao Tome and Principe</asp:ListItem>
<asp:ListItem value="SA" meta:resourcekey="ListItemResource192">Saudi Arabia</asp:ListItem>
<asp:ListItem value="SN" meta:resourcekey="ListItemResource193">Senegal</asp:ListItem>
<asp:ListItem value="RS" meta:resourcekey="ListItemResource194">Serbia</asp:ListItem>
<asp:ListItem value="SC" meta:resourcekey="ListItemResource195">Seychelles</asp:ListItem>
<asp:ListItem value="SL" meta:resourcekey="ListItemResource196">Sierra Leone</asp:ListItem>
<asp:ListItem value="SG" meta:resourcekey="ListItemResource197">Singapore</asp:ListItem>
<asp:ListItem value="SK" meta:resourcekey="ListItemResource198">Slovakia</asp:ListItem>
<asp:ListItem value="SI" meta:resourcekey="ListItemResource199">Slovenia</asp:ListItem>
<asp:ListItem value="SB" meta:resourcekey="ListItemResource200">Solomon Islands</asp:ListItem>
<asp:ListItem value="SO" meta:resourcekey="ListItemResource201">Somalia</asp:ListItem>
<asp:ListItem value="ZA" meta:resourcekey="ListItemResource202">South Africa</asp:ListItem>
<asp:ListItem value="GS" meta:resourcekey="ListItemResource203">South Georgia and The South Sandwich Islands</asp:ListItem>
<asp:ListItem value="ES" meta:resourcekey="ListItemResource204">Spain</asp:ListItem>
<asp:ListItem value="LK" meta:resourcekey="ListItemResource205">Sri Lanka</asp:ListItem>
<asp:ListItem value="SD" meta:resourcekey="ListItemResource206">Sudan</asp:ListItem>
<asp:ListItem value="SR" meta:resourcekey="ListItemResource207">Suriname</asp:ListItem>
<asp:ListItem value="SJ" meta:resourcekey="ListItemResource208">Svalbard and Jan Mayen</asp:ListItem>
<asp:ListItem value="SZ" meta:resourcekey="ListItemResource209">Swaziland</asp:ListItem>
<asp:ListItem value="SE" meta:resourcekey="ListItemResource210">Sweden</asp:ListItem>
<asp:ListItem value="CH" meta:resourcekey="ListItemResource211">Switzerland</asp:ListItem>
<asp:ListItem value="SY" meta:resourcekey="ListItemResource212">Syrian Arab Republic</asp:ListItem>
<asp:ListItem value="TW" meta:resourcekey="ListItemResource213">Taiwan, Province of China</asp:ListItem>
<asp:ListItem value="TJ" meta:resourcekey="ListItemResource214">Tajikistan</asp:ListItem>
<asp:ListItem value="TZ" meta:resourcekey="ListItemResource215">Tanzania, United Republic of</asp:ListItem>
<asp:ListItem value="TH" meta:resourcekey="ListItemResource216">Thailand</asp:ListItem>
<asp:ListItem value="TL" meta:resourcekey="ListItemResource217">Timor-leste</asp:ListItem>
<asp:ListItem value="TG" meta:resourcekey="ListItemResource218">Togo</asp:ListItem>
<asp:ListItem value="TK" meta:resourcekey="ListItemResource219">Tokelau</asp:ListItem>
<asp:ListItem value="TO" meta:resourcekey="ListItemResource220">Tonga</asp:ListItem>
<asp:ListItem value="TT" meta:resourcekey="ListItemResource221">Trinidad and Tobago</asp:ListItem>
<asp:ListItem value="TN" meta:resourcekey="ListItemResource222">Tunisia</asp:ListItem>
<asp:ListItem value="TR" meta:resourcekey="ListItemResource223">Turkey</asp:ListItem>
<asp:ListItem value="TM" meta:resourcekey="ListItemResource224">Turkmenistan</asp:ListItem>
<asp:ListItem value="TC" meta:resourcekey="ListItemResource225">Turks and Caicos Islands</asp:ListItem>
<asp:ListItem value="TV" meta:resourcekey="ListItemResource226">Tuvalu</asp:ListItem>
<asp:ListItem value="UG" meta:resourcekey="ListItemResource227">Uganda</asp:ListItem>
<asp:ListItem value="UA" meta:resourcekey="ListItemResource228">Ukraine</asp:ListItem>
<asp:ListItem value="AE" meta:resourcekey="ListItemResource229">United Arab Emirates</asp:ListItem>
<asp:ListItem value="GB" meta:resourcekey="ListItemResource230">United Kingdom</asp:ListItem>
<asp:ListItem value="US" meta:resourcekey="ListItemResource231">United States</asp:ListItem>
<asp:ListItem value="UM" meta:resourcekey="ListItemResource232">United States Minor Outlying Islands</asp:ListItem>
<asp:ListItem value="UY" meta:resourcekey="ListItemResource233">Uruguay</asp:ListItem>
<asp:ListItem value="UZ" meta:resourcekey="ListItemResource234">Uzbekistan</asp:ListItem>
<asp:ListItem value="VU" meta:resourcekey="ListItemResource235">Vanuatu</asp:ListItem>
<asp:ListItem value="VE" meta:resourcekey="ListItemResource236">Venezuela</asp:ListItem>
<asp:ListItem value="VN" meta:resourcekey="ListItemResource237">Viet Nam</asp:ListItem>
<asp:ListItem value="VG" meta:resourcekey="ListItemResource238">Virgin Islands, British</asp:ListItem>
<asp:ListItem value="VI" meta:resourcekey="ListItemResource239">Virgin Islands, U.S.</asp:ListItem>
<asp:ListItem value="WF" meta:resourcekey="ListItemResource240">Wallis and Futuna</asp:ListItem>
<asp:ListItem value="EH" meta:resourcekey="ListItemResource241">Western Sahara</asp:ListItem>
<asp:ListItem value="YE" meta:resourcekey="ListItemResource242">Yemen</asp:ListItem>
<asp:ListItem value="ZM" meta:resourcekey="ListItemResource243">Zambia</asp:ListItem>
<asp:ListItem value="ZW" meta:resourcekey="ListItemResource244">Zimbabwe</asp:ListItem>

                                </asp:DropDownList>
                                
                                
                                
                                
                                
                                
                                
                                <div class="separator"></div>
                                
                                <p><asp:Literal ID="Literal17" runat="server" Text="Città" meta:resourcekey="Literal17Resource1"></asp:Literal></p>
                                <asp:TextBox ClientIDMode="Static" ID="inputTitle" class="span6" placeholder="" runat="server" meta:resourcekey="inputTitleResource1"></asp:TextBox>

								<div class="separator"></div>
                                <p><asp:Literal ID="Literal18" runat="server" Text="Provincia" meta:resourcekey="Literal18Resource1"></asp:Literal></p>
								<asp:TextBox ClientIDMode="Static" ID="Text1" class="span6" placeholder="" runat="server" meta:resourcekey="Text1Resource1"></asp:TextBox>

                                <div class="separator"></div>
								<p><asp:Literal ID="Literal19" runat="server" Text="via" meta:resourcekey="Literal19Resource1"></asp:Literal></p>
                                <asp:TextBox ClientIDMode="Static" ID="Text2" class="span6" placeholder="" runat="server" meta:resourcekey="Text2Resource1"></asp:TextBox>

								<div class="separator"></div>
								<p><asp:Literal ID="Literal20" runat="server" Text="numero" meta:resourcekey="Literal20Resource1"></asp:Literal></p>
                                <asp:TextBox ClientIDMode="Static" ID="Text3" class="span6" placeholder="" runat="server" meta:resourcekey="Text3Resource1"></asp:TextBox>

								<div class="separator"></div>
                                
                          </div>
						</div>
<!-- end gruppo-->
<!--  gruppo-->
                        <div class="row-fluid">
                   <div class="span3">
                       <strong><asp:Literal ID="Literal21" runat="server" Text="Referente" meta:resourcekey="Literal21Resource1"></asp:Literal></strong>
						<p class="muted"><asp:Literal ID="Literal22" runat="server" Text="Modifica informazioni relative alla persona referente di questo impianto" meta:resourcekey="Literal22Resource1"></asp:Literal></p>
                        		</div>
                                <div class="span9">
                                    <p><asp:Literal ID="Literal23" runat="server" Text="Nome" meta:resourcekey="Literal23Resource1"></asp:Literal></p>
                                    <asp:TextBox ClientIDMode="Static" ID="Text4" class="span6" placeholder="" runat="server" meta:resourcekey="Text4Resource1"></asp:TextBox>


								<div class="separator"></div>
                                    <p><asp:Literal ID="Literal25" runat="server" Text="Recapito telefonico" meta:resourcekey="Literal25Resource1"></asp:Literal></p>
                                    <asp:TextBox ClientIDMode="Static" ID="Text6" class="span6" placeholder="" runat="server" meta:resourcekey="Text6Resource1"></asp:TextBox>

								<div class="separator"></div>
                                    <p><asp:Literal ID="Literal26" runat="server" Text="Email" meta:resourcekey="Literal26Resource1"></asp:Literal></p>
                                    <asp:TextBox ClientIDMode="Static" ID="Text7" class="span6" placeholder="" runat="server" meta:resourcekey="Text7Resource1"></asp:TextBox>
                            	<div class="separator"></div>
                                </div>
                                </div>

<!-- end gruppo-->
                    <!--  gruppo-->
                    <div class="row-fluid">
                       <div class="span3">
                       <strong><asp:Literal ID="Literal2" runat="server" Text="Mail Alert" ></asp:Literal></strong>
						<p class="muted"><asp:Literal ID="Literal3" runat="server" Text="Send Alert mail when the instrument is disconnected for more than 1 hour" ></asp:Literal></p>
                        		</div>
                        <div class="span9">
                                <div class="separator"></div>
                                    <p><asp:Literal ID="alarmMailLiteral" runat="server" Text="Email" meta:resourcekey="alarmMailLiteralResource1"></asp:Literal></p>
                                    <asp:checkbox ID="alarmMail" ClientIDMode="Static"  class="span6"  runat="server" meta:resourcekey="alarmMailResource1"  ></asp:checkbox>							
                            <div class="separator"></div>
                         </div>
                        </div>
                    <!-- end gruppo-->
<!--  gruppo-->
                        <div class="row-fluid">
                   <div class="span3">
                       <strong><asp:Literal ID="Literal27" runat="server" Text="Utilizzatore" meta:resourcekey="Literal27Resource1"></asp:Literal></strong>
                       <p class="muted"><asp:Literal ID="Literal28" runat="server" Text="Modifica informazioni relative alla persona Utilizzatore dell' impianto" meta:resourcekey="Literal28Resource1"></asp:Literal></p>
                        		</div>
                                <div class="span9">

                            <p><asp:Literal ID="Literal50" runat="server" Text="Seleziona un Utilizzatore" meta:resourcekey="Literal50Resource1"></asp:Literal>

                                    </p>
								<asp:DropDownList ID="utilizzatore_list" ClientIDMode="Static" runat="server" meta:resourcekey="utilizzatore_listResource1">
                                    <asp:ListItem Value="0" meta:resourcekey="ListItemResource245">Nessuno..</asp:ListItem>
                                    <asp:ListItem Value="1" meta:resourcekey="ListItemResource246">Nuovo</asp:ListItem>
								</asp:DropDownList>
					
                            	
                            
                                    <a href="#" id="aggiungiUtente" class="btn btn-primary view-all"><asp:Literal ID="aggiungi" runat="server" Text="Aggiungi" meta:resourcekey="aggiungi_listResource1"></asp:Literal></a>
                                    <asp:Literal ID="java_script" runat="server"></asp:Literal>
                                    <p> </p>
                                    <span class="span6" style="padding-bottom:30px;">
                                        <asp:Literal ID="table_create" runat="server"></asp:Literal>
                                        

                                    </span>


                                </div>
                                </div>
<!-- end gruppo-->
<!--  gruppo-->
                         <div class="row-fluid">
                   <div class="span3">
                       
                       <strong><asp:Literal ID="Literal32" runat="server" Text="Gruppo impianto" meta:resourcekey="Literal32Resource1"></asp:Literal></strong>
						<p class="muted"><asp:Literal ID="Literal33" runat="server" Text="Modifica il gruppo di appartenenza dell'impianto" meta:resourcekey="Literal33Resource1"></asp:Literal></p>
                        </div>
                        <div class="span9">
								<p><asp:Literal ID="Literal34" runat="server" Text="Seleziona un Gruppo già esistente" meta:resourcekey="Literal34Resource1"></asp:Literal></p>
								<asp:DropDownList ClientIDMode="Static" ID="gruppi" runat="server" meta:resourcekey="gruppiResource1">
                                    <asp:ListItem Value="nuovo" meta:resourcekey="ListItemResource247">Nuovo..</asp:ListItem>
                                    <asp:ListItem Value="emec>emec1" meta:resourcekey="ListItemResource248">emec</asp:ListItem>
								</asp:DropDownList>
								
                                <div class="separator"></div>
                            <p><asp:Literal ID="Literal35" runat="server" Text="Modifica o crea un nuovo gruppo" meta:resourcekey="Literal35Resource1"></asp:Literal></p>
                            <asp:TextBox ID="textGruppo" ClientIDMode="Static" class="span6" placeholder=""  onblur="javascript: Changed_channel( 'textGruppo',0);" runat="server" meta:resourcekey="textGruppoResource1"></asp:TextBox>
                        </div>
                        </div>
<!-- end gruppo-->
<!--  gruppo-->
                        <div class="row-fluid">
                   <div class="span3">

                       <strong><asp:Literal ID="Literal36" runat="server" Text="Modifica Sotto Gruppo impianto" meta:resourcekey="Literal36Resource1"></asp:Literal></strong>
						<p class="muted"><asp:Literal ID="Literal37" runat="server" Text="Aggiungi il nuovo impianto ad un Sotto Gruppo" meta:resourcekey="Literal37Resource1"></asp:Literal></p>

                        </div>
                        <div class="span9">

                            <p><asp:Literal ID="Literal38" ClientIDMode="Static" runat="server" Text="Seleziona un Sotto Gruppo già esistente" meta:resourcekey="Literal38Resource1"></asp:Literal></p>								
								<asp:DropDownList ID="sottogruppi" ClientIDMode="Static" runat="server" meta:resourcekey="sottogruppiResource1">
                                    <asp:ListItem Value="0" meta:resourcekey="ListItemResource249">Nuovo..</asp:ListItem>
                                    <asp:ListItem Value="1" meta:resourcekey="ListItemResource250">Italy - Roma - via arice, 1</asp:ListItem>
								</asp:DropDownList>
                                <div class="separator"></div>
                            <p><asp:Literal ID="Literal39" runat="server" Text="Modifica o Crea un nuovo Sotto Gruppo" meta:resourcekey="Literal39Resource1"></asp:Literal></p>	
                            <asp:TextBox ID="Text11" ClientIDMode="Static" class="span6" placeholder=""  onblur="javascript: Changed_channel( 'Text11',0);" runat="server" meta:resourcekey="Text11Resource1"></asp:TextBox>
                        </div>
                        </div>
<!-- end gruppo-->
						</div>
                 <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ClientIDMode="Static"  ID="save_modifica_impianto_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy"  text="Modifica Impianto" Font-Bold="True" meta:resourcekey="save_modifica_impianto_newResource1" /><i></i></b>

            </div>
                    </div>
                </div>
        
            </div>

    <script type="text/javascript" src="common/validator_general_modificaimpianto.js?v=1.1"></script>
    <script type="text/javascript" src="common/validator_general_notify.js"></script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script_footer" runat="server">
    <script src="theme/scripts/demo/notifications.js"></script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="script_at_end" runat="server">
    <script src="theme/scripts/demo/notifications.js"></script>
      <script >
          var sPageURL = window.location.search.substring(1);
          var i = 0;
          var val;
          var indice = 0;
          var pagina_split = sPageURL.split('&');

          for (i = 0; i < pagina_split.length; i++) {
              val = pagina_split[i].split("=");
              if (val[0] == 'result') {
                  var risultato = parseInt(val[1]);
                  if (risultato == 1) { //risposta corretta
                      result_setpoint_change(modify_plant_ok);
                  }
                  if (risultato == 2) { //strumento occupato
                      result_setpoint_change(modify_plant_error);
                  }

              }
          }
</script>
</asp:Content>
