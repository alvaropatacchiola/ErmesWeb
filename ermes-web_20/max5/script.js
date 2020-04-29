
//canvasNew.initCanvas();


function CanvasNew(idCanvas, idDiv, labelCanale, valueCanale, fullScaleValue, factorDivideValue, minValueAlarm, maxValueAlarm, riga1Enable, riga1Min, riga1Max, riga2Enable, riga2Min, riga2Max, riga3Enable, riga3Min, riga3Max, riga4Enable, riga4Min, riga4Max,da,db,pa,pb,level1,level2,level3,level4,ad,ar) {

    console.log(level1, level2, level3, level4)
                            this.$myCanvas = $(idCanvas);
                            this.idDivContainer = idDiv;
                            
                            this.fullscale = fullScaleValue;
                            this.factorDivide = factorDivideValue;

                            this.valuePh = valueCanale;
                            this.labelpH = labelCanale

                            this.heightGlobal = 20;
                            this.minAlarmpH = minValueAlarm;

                            this.minSetpoint1 = riga1Min;
                            this.maxSetpoint1 = riga1Max;
                            this.leval1 = level1;

                            this.minSetpoint2 = riga2Min;
                            this.maxSetpoint2 = riga2Max;
                            this.leval2 = level2;
                            this.minSetpoint3 = riga3Min;
                            this.maxSetpoint3 = riga3Max;
                            this.leval3 = level3;
                            this.minSetpoint4 = riga4Min;
                            this.maxSetpoint4 = riga4Max;
                            this.leval4 = level4;
                            this.ad = ad;
                            this.ar = ar;
                            this.enableRiga1 = riga1Enable;
                            if (da == 1 )
                                this.da = "ON";
                            if (da == 0)
                                this.da = "OFF";
                            if (db == 1)
                                this.db = "ON";
                            if (db == 0)
                                this.db = "OFF";
                            if (pa > 0)
                                this.pa = pa.toString() + "Pm";
                            else
                                this.pa = "OFF";
                            if (pb > 0)
                                this.pb = pb.toString() + "Pm";
                            else
                                this.pb = "OFF";


                            this.enableRiga2 = riga2Enable;

                            this.enableRiga3 = riga3Enable;

                            this.enableRiga4 = riga4Enable;


                            this.maxAlarmpH = maxValueAlarm;
                            
                            this.xCanvasLeft = 10;
                            //ph min 4.50
                            this.widthCanvasLeft=0;
                            this.widthCanvasLeftGrey = 0;

                            //ph range 700, 760
                            this.widthCanvasCenterGreen1 = 0;
                            this.widthCanvasCenterGreen1 = 0;


    //ph range 700, 760


                            //ph max 8.50
                            this.widthCanvasRightRed = 0;

                            this.widthCanvasRightGrey = 0;


                            this.colorGrey="";
                            this.colorGreen = "";
                            this.colorRed = "";
                            this.colorOrange = "";
                            this.yCanvas = "";

                            //this.pippo = initCanvas;
    

                            //this.initCanvas();


                            this.calcolaPixel = function (valore, sizeBox, maxRange, margin) {
                                return ((sizeBox - margin) * valore) / maxRange;
                            };
    
    //---------------------------------------function
                     this.disegnaLabelLayer = function (xLayer, yLayer, testo, colore, widthTemp, name, heightLayer, fontSize) {
                         //console.log(xLayer)
                         if (xLayer < this.xCanvasLeft)
                             xLayer = xLayer + this.xCanvasLeft + 20;
                         this.$myCanvas
                                     .addLayer({
                                         type: 'rectangle',
                                         name: name,
                                         fillStyle: colore,
                                         fromCenter: false,
                                         x: xLayer, y: yLayer,
                                         width: testo.length * (fontSize), height: heightLayer
                                     })
                                     .addLayer({
                                         type: 'text',
                                         name: name + 'Text',
                                         fillStyle: 'black',
                                         fromCenter: false,
                                         fontStyle: 'bold',
                                         fontSize: fontSize.toString() + 'pt',
                                         fontFamily: 'Verdana, sans-serif',
                                         x: xLayer/*+((testo.length *  fontSize))*/, y: yLayer + (0) + 3,
                                         maxWidth: widthTemp,
                                         align: 'center',
                                         text: testo
                                     })
                                     .drawLayers();

                         this.$myCanvas.setLayer(name, {
                             width: this.$myCanvas.getLayer(name + 'Text').width
                         })
                        .drawLayers();
                     };
    //---------------------------------------function
                        this.disegnaLabel = function (xTesto, yTesto, testo, colore, widthTemp) {
                            this.$myCanvas
                            .drawRect({
                                layer: true,
                                //fillStyle: colorGrey,
                                fillStyle: colore,
                                strokeWidth: 2,
                                x: xTesto + 5, y: yTesto + 12,
                                //width: this.$myCanvas.measureText('myText').width , 
                                //height: this.$myCanvas.measureText('myText').height 
                                width: widthTemp,
                                height: 15

                            })
                            .drawText({
                                layer: true,
                                //name: 'myText',
                                fillStyle: 'black',
                                strokeWidth: 2,
                                x: xTesto + 5, y: yTesto + 12,
                                fontSize: '8pt',
                                fontFamily: 'Verdana, sans-serif',
                                text: testo
                            });

                        };
    //---------------------------------------function
                        this.disegnaTriangolo90 = function (xTriangolo, yTriangolo, left, nomeTemp) {
                            var triangolo90;
                            if (left) {
                                xTriangolo = xTriangolo - 8;
                                triangolo90 = {
                                    type: 'line',
                                    name: nomeTemp,
                                    fromCenter: false,
                                    strokeStyle: 'white',
                                    fillStyle: '#000',
                                    strokeWidth: 1,
                                    x1: xTriangolo + 0, y1: yTriangolo + 0,
                                    x2: xTriangolo + 8, y2: yTriangolo + 0,
                                    x3: xTriangolo + 8, y3: yTriangolo + 8,
                                    closed: true
                                }
                            }
                            else {
                                //xTriangolo = xTriangolo - 8;
                                triangolo90 = {
                                    type: 'line',
                                    name: nomeTemp,
                                    fromCenter: false,
                                    strokeStyle: 'white',
                                    fillStyle: '#000',
                                    strokeWidth: 1,
                                    x1: xTriangolo + 0, y1: yTriangolo + 0,
                                    x2: xTriangolo + 0, y2: yTriangolo + 8,
                                    x3: xTriangolo + 8, y3: yTriangolo + 0,

                                    closed: true
                                }
                            }
                            return triangolo90
                        };
    //---------------------------------------function
                        this.disegnaTesto = function (xTesto, yTesto, testo, fontSize, colore) {
                            this.$myCanvas
                            .drawText({
                                layer: true,
                                fromCenter: false,
                                //name: 'myText',
                                fillStyle: 'black',
                                strokeWidth: 2,
                                x: xTesto, y: yTesto,
                                fontSize: fontSize.toString() + 'pt',
                                fontFamily: 'Verdana, sans-serif',
                                text: testo
                            });

                        };
    //---------------------------------------function
                        this.disegnaBarraGraduata = function () {
                            var i = 0;
                            var labelNumeric;
                            var positionNumeric;
                            this.$myCanvas
                                        .addLayer({
                                            type: 'rectangle',
                                            name: 'barraOrizzontale',
                                            fillStyle: this.colorGrey,
                                            fromCenter: false,
                                            x: this.xCanvasLeft, y: this.$myCanvas.height() - 60,
                                            width: this.$myCanvas.width() - (this.xCanvasLeft * 2), height: 2
                                        })
                                        .drawLayers();
                            for (i = 0; i < 8; i++) {
                                this.$myCanvas
                                        .addLayer({
                                            type: 'rectangle',
                                            name: 'barraOrizzontale' + i.toString(),
                                            fillStyle: this.colorGrey,
                                            fromCenter: false,
                                            x: this.$myCanvas.getLayer("barraOrizzontale").x + (i * (this.$myCanvas.getLayer("barraOrizzontale").width / 7)), y: this.xCanvasLeft,
                                            width: 1, height: this.$myCanvas.getLayer("barraOrizzontale").y//this.$myCanvas.height() - (this.this.xCanvasLeft * 2) - this.xCanvasLeft
                                        })
                                        .drawLayers();
                                labelNumeric = parseInt(((this.fullscale * i) / 7) / this.factorDivide);
                                positionNumeric = (labelNumeric.toString().length * 2) + 5;
                                if ((i == 7)&&(labelNumeric.toString().length > 2))
                                    positionNumeric = positionNumeric + 10;
                                this.disegnaTesto(this.$myCanvas.getLayer("barraOrizzontale" + i.toString()).x - positionNumeric /*10*/, this.$myCanvas.getLayer("barraOrizzontale" + i.toString()).y + this.$myCanvas.getLayer("barraOrizzontale" + i.toString()).height, labelNumeric, 10, this.colorGrey);
                            }
                        };
    //---------------------------------------function
                        this.disegnaLegenda = function (posizioneX, posizioneY, colore, testoLegenda) {
                            var posizioneXLegenda = posizioneX + this.$myCanvas.getLayer("barraOrizzontale").x;
                            var posizioneYLegenda = posizioneY + this.$myCanvas.getLayer("barraOrizzontale").y + 40;
                            this.$myCanvas
                            .drawRect({
                                name: 'legend' + posizioneXLegenda.toString(),
                                layer: true,
                                fillStyle: colore,
                                x: posizioneXLegenda, y: posizioneYLegenda,
                                width: 10,
                                height: 10
                            });
                            this.disegnaTesto(posizioneXLegenda + 10, posizioneYLegenda - 8, testoLegenda, 10, "black")
                        };
    //---------------------------------------function
                        this.aggiungiLayer = function (xCanvasLeftTemp, yCanvasTemp, lines, widthCanvasCenterGreenTemp, widthCanvasLeftGreyTemp, widthCanvasRightGreyTemp, minSetpointpHEnable, minSetpointpHTemp, maxSetpointpHTemp, testo, livello, dosing, reading) {
                            var positionLinea = 0;
                            var coloreGreyLocal;
                            //if ()
                            this.$myCanvas
                                        .addLayer({
                                            type: 'rectangle',
                                            name: 'redBoxL' + yCanvasTemp.toString(),
                                            fillStyle: this.colorRed,
                                            fromCenter: false,
                                            x: xCanvasLeftTemp, y: yCanvasTemp,
                                            width: this.widthCanvasLeft, height: this.heightGlobal
                                        })
                                        .addLayer({
                                            type: 'rectangle',
                                            name: 'greyBoxL' + yCanvasTemp.toString(),
                                            fillStyle: livello == 1 ? this.colorOrange : this.colorGrey,
                                            fromCenter: false,
                                            x: xCanvasLeftTemp + this.widthCanvasLeft, y: yCanvasTemp,
                                            width: widthCanvasLeftGreyTemp, height: this.heightGlobal
                                        })
                                        // Normally on top, but moved to the bottom
                                        .addLayer({
                                            type: 'rectangle',
                                            name: 'greenBox' + yCanvasTemp.toString(),
                                            fromCenter: false,
                                            fillStyle: this.colorGreen,
                                            x: xCanvasLeftTemp + this.widthCanvasLeft + widthCanvasLeftGreyTemp, y: yCanvasTemp,

                                            width: widthCanvasCenterGreenTemp, height: this.heightGlobal
                                        })
                                        .addLayer({
                                            type: 'rectangle',
                                            name: 'greyBoxR' + yCanvasTemp.toString(),
                                            fromCenter: false,
                                            index: 0,
                                            fillStyle: livello == 1 ? this.colorOrange : this.colorGrey,
                                            x: xCanvasLeftTemp + this.widthCanvasLeft + widthCanvasLeftGreyTemp + widthCanvasCenterGreenTemp, y: yCanvasTemp,
                                            width: widthCanvasRightGreyTemp, height: this.heightGlobal
                                        })
                                        .addLayer({
                                            type: 'rectangle',
                                            name: 'redBoxR' + yCanvasTemp.toString(),
                                            fillStyle: this.colorRed,
                                            fromCenter: false,
                                            x: xCanvasLeftTemp + this.widthCanvasLeft + widthCanvasLeftGreyTemp + widthCanvasCenterGreenTemp + widthCanvasRightGreyTemp, y: yCanvasTemp,
                                            width: this.widthCanvasRightRed, height: this.heightGlobal
                                        })
                                        .drawLayers();

                            positionLinea = xCanvasLeftTemp + this.calcolaPixel(this.valuePh, this.$myCanvas.width(), this.fullscale, xCanvasLeftTemp * 2);

                            if (lines) {
                                this.$myCanvas
                                            .addLayer({
                                                type: 'rectangle',
                                                name: 'linesR',
                                                fillStyle: 'black',
                                                strokeStyle: 'white',
                                                fromCenter: false,
                                                x: xCanvasLeftTemp + this.calcolaPixel(this.valuePh, this.$myCanvas.width(), this.fullscale, xCanvasLeftTemp * 2), y: 40,
                                                width: 3, height: 215
                                            })
                                            //rettangolini
                                            .addLayer({
                                                type: 'polygon',
                                                name: 'linesRtriangle',
                                                fromCenter: false,
                                                strokeStyle: 'white',
                                                fillStyle: 'black',
                                                strokeWidth: 1,
                                                //x: xCanvasLeft + this.widthCanvasLeft - 6, y: this.yCanvas + this.heightGlobal - 8,
                                                x: this.$myCanvas.getLayer("linesR").x - 4, y: this.$myCanvas.getLayer("linesR").y - 12,
                                                radius: 6,
                                                rotate: 180,
                                                sides: 3
                                            })
                                            .drawLayers();
                            }
                            
                            if (this.minAlarmpH > 0){
                            this.$myCanvas
                                        .addLayer({
                                            type: 'polygon',
                                            name: 'polygonL' + yCanvasTemp.toString(),
                                            fromCenter: false,
                                            strokeStyle: 'white',
                                            fillStyle: 'black',
                                            strokeWidth: 1,
                                            //x: xCanvasLeft + this.widthCanvasLeft - 6, y: this.yCanvas + this.heightGlobal - 8,
                                            x: this.$myCanvas.getLayer("greyBoxL" + yCanvasTemp.toString()).x /*- this.$myCanvas.getLayer("greyBoxL").width*/ - 6, y: this.$myCanvas.getLayer("greyBoxL" + yCanvasTemp.toString()).y + this.heightGlobal - 8,
                                            radius: 6,
                                            sides: 3
                                        })
                                    .drawLayers();
                            }
                            
                            if (this.maxAlarmpH > 0) {
                                this.$myCanvas
                                            .addLayer({
                                                type: 'polygon',
                                                name: 'polygonR' + yCanvasTemp.toString(),
                                                fromCenter: false,
                                                strokeStyle: 'white',
                                                fillStyle: 'black',
                                                strokeWidth: 1,
                                                x: this.$myCanvas.getLayer("greyBoxR" + yCanvasTemp.toString()).x + this.$myCanvas.getLayer("greyBoxR" + yCanvasTemp.toString()).width - 6, y: this.$myCanvas.getLayer("greyBoxR" + yCanvasTemp.toString()).y + this.heightGlobal - 8,
                                                radius: 6,
                                                sides: 3
                                            })
                                    .drawLayers();
                            }
                            if ((testo.length > 0) /*&& (lines)*/) {
                                
                                this.$myCanvas
                                            .addLayer({
                                                type: 'polygon',
                                                name: 'polygonCentral' + yCanvasTemp.toString(),
                                                fromCenter: false,
                                                strokeStyle: 'white',
                                                fillStyle: 'red',
                                                strokeWidth: 1,
                                                x: positionLinea + 3, y: yCanvasTemp + (this.heightGlobal / 2) - 6,
                                                radius: 6,
                                                rotate: -90,
                                                sides: 3
                                            })
                                    .drawLayers();
                            }
                            
                            if (minSetpointpHEnable) {
                                this.$myCanvas
                                            .addLayer(this.disegnaTriangolo90(this.$myCanvas.getLayer("greenBox" + yCanvasTemp.toString()).x, this.$myCanvas.getLayer("greenBox" + yCanvasTemp.toString()).y, true, "greenLeft" + yCanvasTemp.toString()))
                                            .addLayer(this.disegnaTriangolo90(this.$myCanvas.getLayer("greenBox" + yCanvasTemp.toString()).x + this.$myCanvas.getLayer("greenBox" + yCanvasTemp.toString()).width, this.$myCanvas.getLayer("greenBox" + yCanvasTemp.toString()).y, false, "greenRight" + yCanvasTemp.toString()))
                                            .drawLayers();
                            }
                            
                            if (this.minAlarmpH > 0)
                                this.disegnaLabel(this.$myCanvas.getLayer("polygonL" + yCanvasTemp.toString()).x, this.$myCanvas.getLayer("polygonL" + yCanvasTemp.toString()).y + this.$myCanvas.getLayer("polygonL" + yCanvasTemp.toString()).radius + 2, (this.minAlarmpH / this.factorDivide).toString(), this.colorGrey, 30)
                            if (this.maxAlarmpH > 0)
                                this.disegnaLabel(this.$myCanvas.getLayer("polygonR" + yCanvasTemp.toString()).x, this.$myCanvas.getLayer("polygonR" + yCanvasTemp.toString()).y + this.$myCanvas.getLayer("polygonR" + yCanvasTemp.toString()).radius + 2, (this.maxAlarmpH / this.factorDivide).toString(), this.colorGrey, 30)
                            if (minSetpointpHEnable){
                                this.disegnaLabel(this.$myCanvas.getLayer("greenLeft" + yCanvasTemp.toString()).x1 - 16, this.$myCanvas.getLayer("greenLeft" + yCanvasTemp.toString()).y1 - 23, (minSetpointpHTemp / this.factorDivide).toString(), this.colorGreen, 30)
                                this.disegnaLabel(this.$myCanvas.getLayer("greenRight" + yCanvasTemp.toString()).x1 + 15, this.$myCanvas.getLayer("greenRight" + yCanvasTemp.toString()).y1 - 23, (maxSetpointpHTemp / this.factorDivide).toString(), this.colorGreen, 30)
                            }
                            if ((testo.length > 0)/*&&(lines)*/) {
                                this.disegnaLabelLayer(this.$myCanvas.getLayer("polygonCentral" + yCanvasTemp.toString()).x + 10, this.$myCanvas.getLayer("polygonCentral" + yCanvasTemp.toString()).y - 3/*+ this.$myCanvas.getLayer("greenLeft").radius + 2*/, testo, "white", 45, "labelStatus" + yCanvasTemp.toString(), 16, 8)
                            }

                            if (lines)
                                this.disegnaLabelLayer(this.$myCanvas.getLayer("linesRtriangle").x - (60 / 2), this.$myCanvas.getLayer("linesRtriangle").y - (25)/*+ this.$myCanvas.getLayer("greenLeft").radius + 2*/, this.labelpH + " " + (this.valuePh / this.factorDivide).toString(), ((ad == 1) ||(ar == 1)) ? this.colorRed :this.colorGrey, 80, "labelChannel", 24, 12)
                            
                        };
    //---------------------------------------function
                        this.updateCanvas = function () {
                            this.disegnaBarraGraduata();
                            var calcolo = 0;
                            var somma = 0;
                            var lines = false
                            if (this.enableRiga1){
                                calcolo = calcolo + 70
                            }
                            if (this.enableRiga2)
                                calcolo = calcolo + 70
                            if (this.enableRiga3)
                                calcolo = calcolo + 70
                            if (this.enableRiga4)
                                calcolo = calcolo + 70

                            if (calcolo == 0) {
                                
                                if (this.maxAlarmpH > 0)
                                    this.widthCanvasRightGrey = this.calcolaPixel(this.maxAlarmpH, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.maxSetpoint1, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2);
                                else
                                    this.widthCanvasRightGrey = this.calcolaPixel(this.fullscale, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.maxSetpoint1, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2);

                                this.widthCanvasLeftGrey = this.calcolaPixel(this.minSetpoint1, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2) - this.widthCanvasLeft;
                                this.aggiungiLayer(this.xCanvasLeft, this.yCanvas + 70, true, this.widthCanvasCenterGreen1, this.widthCanvasLeftGrey, this.widthCanvasRightGrey, this.enableRiga1, this.minSetpoint1, this.maxSetpoint1, "", this.leval1, this.ad,this.ar);
                            }
                            if (calcolo == 70) {
                                if (this.enableRiga1) {
                                    this.widthCanvasLeftGrey = this.calcolaPixel(this.minSetpoint1, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2) - this.widthCanvasLeft;
                                    if (this.maxAlarmpH > 0)
                                        this.widthCanvasRightGrey = this.calcolaPixel(this.maxAlarmpH, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.maxSetpoint1, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2);
                                    else
                                        this.widthCanvasRightGrey = this.calcolaPixel(this.fullscale, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.maxSetpoint1, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2);

                                    this.aggiungiLayer(this.xCanvasLeft, this.yCanvas + 70, lines, this.widthCanvasCenterGreen1, this.widthCanvasLeftGrey, this.widthCanvasRightGrey, this.enableRiga1, this.minSetpoint1, this.maxSetpoint1, this.da, this.leval1, this.ad, this.ar);
                                    lines = true
                                }
                                if (this.enableRiga2) {
                                    this.widthCanvasLeftGrey = this.calcolaPixel(this.minSetpoint2, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2) - this.widthCanvasLeft;
                                    if (this.maxAlarmpH > 0)
                                        this.widthCanvasRightGrey = this.calcolaPixel(this.maxAlarmpH, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.maxSetpoint2, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2);
                                    else
                                        this.widthCanvasRightGrey = this.calcolaPixel(this.fullscale, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.maxSetpoint2, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2);

                                    this.aggiungiLayer(this.xCanvasLeft, this.yCanvas + 70, lines, this.widthCanvasCenterGreen2, this.widthCanvasLeftGrey, this.widthCanvasRightGrey, this.enableRiga2, this.minSetpoint2, this.maxSetpoint2, this.db, this.leval2, this.ad, this.ar);
                                    lines = true
                                }
                                if (this.enableRiga3) {
                                    this.widthCanvasLeftGrey = this.calcolaPixel(this.minSetpoint3, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2) - this.widthCanvasLeft;
                                    if (this.maxAlarmpH > 0)
                                        this.widthCanvasRightGrey = this.calcolaPixel(this.maxAlarmpH, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.maxSetpoint3, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2);
                                    else
                                        this.widthCanvasRightGrey = this.calcolaPixel(this.fullscale, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.maxSetpoint3, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2);
                                    this.aggiungiLayer(this.xCanvasLeft, this.yCanvas + 70, lines, this.widthCanvasCenterGreen3, this.widthCanvasLeftGrey, this.widthCanvasRightGrey, this.enableRiga3, this.minSetpoint3, this.maxSetpoint3, this.pa, this.leval3, this.ad, this.ar);
                                    lines = true
                                }
                                if (this.enableRiga4) {
                                    this.widthCanvasLeftGrey = this.calcolaPixel(this.minSetpoint4, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2) - this.widthCanvasLeft;
                                    if (this.maxAlarmpH > 0)
                                        this.widthCanvasRightGrey = this.calcolaPixel(this.maxAlarmpH, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.maxSetpoint4, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2);
                                    else
                                        this.widthCanvasRightGrey = this.calcolaPixel(this.fullscale, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.maxSetpoint4, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2);
                                    this.aggiungiLayer(this.xCanvasLeft, this.yCanvas + 70, lines, this.widthCanvasCenterGreen4, this.widthCanvasLeftGrey, this.widthCanvasRightGrey, this.enableRiga4, this.minSetpoint4, this.maxSetpoint4, this.pb, this.leval4, this.ad, this.ar);
                                    lines = true
                                }

                            }
                            if (calcolo >= 140) {
                                
                                if (this.enableRiga1) {
                                    this.widthCanvasLeftGrey = this.calcolaPixel(this.minSetpoint1, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2) - this.widthCanvasLeft;
                                    if (this.maxAlarmpH > 0)
                                        this.widthCanvasRightGrey = this.calcolaPixel(this.maxAlarmpH, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.maxSetpoint1, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2);
                                    else
                                        this.widthCanvasRightGrey = this.calcolaPixel(this.fullscale, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.maxSetpoint1, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2);

                                    this.aggiungiLayer(this.xCanvasLeft, this.yCanvas + somma, lines, this.widthCanvasCenterGreen1, this.widthCanvasLeftGrey, this.widthCanvasRightGrey, this.enableRiga1, this.minSetpoint1, this.maxSetpoint1, this.da, this.leval1, this.ad, this.ar);
                                    somma = somma + 70;
                                    if (somma == 70) lines = true
                                }
                                if (this.enableRiga2) {
                                    this.widthCanvasLeftGrey = this.calcolaPixel(this.minSetpoint2, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2) - this.widthCanvasLeft;
                                    if (this.maxAlarmpH > 0)
                                        this.widthCanvasRightGrey = this.calcolaPixel(this.maxAlarmpH, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.maxSetpoint2, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2);
                                    else
                                        this.widthCanvasRightGrey = this.calcolaPixel(this.fullscale, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.maxSetpoint2, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2);

                                    this.aggiungiLayer(this.xCanvasLeft, this.yCanvas + somma, lines, this.widthCanvasCenterGreen2, this.widthCanvasLeftGrey, this.widthCanvasRightGrey, this.enableRiga2, this.minSetpoint2, this.maxSetpoint2, this.db, this.leval2, this.ad, this.ar);
                                    somma = somma + 70;
                                    if (somma == 70) lines = true
                                    
                                }
                                if (this.enableRiga3) {
                                    this.widthCanvasLeftGrey = this.calcolaPixel(this.minSetpoint3, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2) - this.widthCanvasLeft;
                                    if (this.maxAlarmpH > 0)
                                        this.widthCanvasRightGrey = this.calcolaPixel(this.maxAlarmpH, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.maxSetpoint3, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2);
                                    else
                                        this.widthCanvasRightGrey = this.calcolaPixel(this.fullscale, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.maxSetpoint3, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2);
                                    this.aggiungiLayer(this.xCanvasLeft, this.yCanvas + somma, lines, this.widthCanvasCenterGreen3, this.widthCanvasLeftGrey, this.widthCanvasRightGrey, this.enableRiga3, this.minSetpoint3, this.maxSetpoint3, this.pa, this.leval3, this.ad, this.ar);
                                    somma = somma + 70;
                                    if (somma == 70) lines = true
                                }
                                if (this.enableRiga4) {
                                    this.widthCanvasLeftGrey = this.calcolaPixel(this.minSetpoint4, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2) - this.widthCanvasLeft;
                                    if (this.maxAlarmpH > 0)
                                        this.widthCanvasRightGrey = this.calcolaPixel(this.maxAlarmpH, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.maxSetpoint4, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2);
                                    else
                                        this.widthCanvasRightGrey = this.calcolaPixel(this.fullscale, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.maxSetpoint4, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2);
                                    this.aggiungiLayer(this.xCanvasLeft, this.yCanvas + somma, lines, this.widthCanvasCenterGreen4, this.widthCanvasLeftGrey, this.widthCanvasRightGrey, this.enableRiga4, this.minSetpoint4, this.maxSetpoint4, this.pb, this.leval4, this.ad, this.ar);
                                    lines = false
                                }

                                //this.aggiungiLayer(this.xCanvasLeft, this.yCanvas, true, this.widthCanvasCenterGreen1);
                                //this.aggiungiLayer(this.xCanvasLeft, this.yCanvas + 70, true, this.widthCanvasCenterGreen1);
                            }

                            if (calcolo == 210) {
                                //this.aggiungiLayer(this.xCanvasLeft, this.yCanvas, true, this.widthCanvasCenterGreen1);
                                //this.aggiungiLayer(this.xCanvasLeft, this.yCanvas + 70, true, this.widthCanvasCenterGreen1);
                                //this.aggiungiLayer(this.xCanvasLeft, this.yCanvas + 140, true, this.widthCanvasCenterGreen1);
                            }
                           /* if ((this.minSetpoint1 > 0) ||(this.maxSetpoint1 > 0) ||
                                (this.minSetpoint2 > 0) ||(this.maxSetpoint2 > 0) ||
                                (this.minSetpoint3 > 0) ||(this.maxSetpoint3 > 0) 
                                (this.minSetpoint4 > 0) ||(this.maxSetpoint4 > 0) 
                                )*/
                           this.disegnaLegenda(0, 0, this.colorGreen, "Range Setpoint");
                           this.disegnaLegenda(150, 0, this.colorRed, "Alarm");
                           this.disegnaLegenda(250, 0, this.colorOrange, "Level");

                            //this.disegnaLegenda(0, 0, this.colorGrey, "Legenda1");
                            
                            //this.disegnaLegenda(200, 0, this.colorGreen, "Range Setpoint");

                            //disegnaLabel(this.$myCanvas.getLayer("greenRight").x,this.$myCanvas.getLayer("greenRight").y + this.$myCanvas.getLayer("greenRight").radius + 2,"7.56",this.colorGreen)



                            // Draw circle as wide as the tex;
                        };
    //---------------------------------------function

                        this.initCanvas = function () {

                            //var xCanvasLeft = 10;
                            /*
                            var canvas = document.querySelector('canvas'),
                            ctx = canvas.getContext('2d');
                            fitToContainer(canvas);*/
                            /* $('#myCanvas').width(700)
                             $('#myCanvas').height(300)
                             this.$myCanvas = $('#myCanvas');*/
                            //$('#myCanvas').width($('#canale1').width())
                            //$('#myCanvas').height($('#canale1').height())
                            
                            this.$myCanvas.attr("width", $(this.idDivContainer).width())
                            this.$myCanvas.css({
                                "maxWidth": $(this.idDivContainer).width()
                            });
                            this.$myCanvas.attr("height", 300)

                            //this.$myCanvas = $('#myCanvas');
                            //ph min 4.50
                            this.widthCanvasLeft = this.calcolaPixel(this.minAlarmpH, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2);
                            
                            this.widthCanvasCenterGreen1 = this.calcolaPixel(this.maxSetpoint1, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.minSetpoint1, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2);
                            this.widthCanvasCenterGreen2 = this.calcolaPixel(this.maxSetpoint2, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.minSetpoint2, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2);
                            this.widthCanvasCenterGreen3 = this.calcolaPixel(this.maxSetpoint3, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.minSetpoint3, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2);
                            this.widthCanvasCenterGreen4 = this.calcolaPixel(this.maxSetpoint4, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.minSetpoint4, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2);

                           // this.widthCanvasLeftGrey = this.calcolaPixel(this.minSetpointpH, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2) - this.widthCanvasLeft;
                            

                            
                            //this.widthCanvasRightGrey = this.calcolaPixel(this.maxAlarmpH, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2) - (this.widthCanvasCenterGreen + this.widthCanvasLeftGrey + this.widthCanvasLeft);

                            //ph max 8.50
                            //this.widthCanvasRightRed = (this.$myCanvas.width() - 20) - this.calcolaPixel(this.maxAlarmpH, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2)
                            if (this.maxAlarmpH > 0)
                                this.widthCanvasRightRed = this.calcolaPixel(this.maxAlarmpH, this.$myCanvas.width(), this.fullscale, this.xCanvasLeft * 2) - (this.widthCanvasCenterGreen + this.widthCanvasLeftGrey + this.widthCanvasLeft + this.widthCanvasRightGrey)
                            

                            
                            
                            /*colori
                            */

                            this.colorGrey = '#cccccc';
                            this.colorGreen = '#a4c408';
                            this.colorRed = "#c33";
                            this.colorOrange = "orange";
                            this.yCanvas = 60;

                            this.updateCanvas();

                        };
    //---------------------------------------function
                        this.explode = function () {
                            //updateCanvas(this.this.widthCanvasLeftGrey);
                            //this.$myCanvas.removeLayer('linesR').drawLayers();
                            this.$myCanvas.setLayer('linesR', {
                                //fillStyle: '#36b',
                                //rotate: 30,
                                x: '+=3',
                                x: '+=3'
                            })
                          .drawLayers();
                            this.$myCanvas.setLayer('labelStatus', {
                                //fillStyle: '#36b',
                                //rotate: 30,
                                x: '+=3'
                            })
                          .drawLayers();
                            this.$myCanvas.setLayer('linesRtriangle', {
                                //fillStyle: '#36b',
                                //rotate: 30,
                                x: '+=3'
                            })
                          .drawLayers();


                            this.$myCanvas.setLayer('labelStatusText', {
                                //fillStyle: '#36b',
                                //rotate: 30,
                                x: '+=3'
                            })
                          .drawLayers();


                            this.$myCanvas.setLayer('polygonCentral', {
                                //fillStyle: '#36b',
                                //rotate: 30,
                                x: this.$myCanvas.getLayer("linesR").x + 3
                            })
                          .drawLayers();

                            this.$myCanvas.setLayer('labelChannel', {
                                //fillStyle: '#36b',
                                //rotate: 30,
                                x: '+=3'
                            })
                          .drawLayers();
                            this.$myCanvas.setLayer('labelChannelText', {
                                //fillStyle: '#36b',
                                //rotate: 30,
                                x: '+=3'
                            })
                          .drawLayers();


                        };
                        //setTimeout(explode, 2000);
                        //setInterval(explode, 2000);

                        $(window).resize(function(){
    
                            this.$myCanvas.clearCanvas();
                            // Remove all layers
                            this.$myCanvas.removeLayers()
                           /* var canvasTemp = document.getElementById('myCanvas');
                            var context = canvasTemp.getContext('2d');
                            context.clearRect(0, 0, canvasTemp.width, canvasTemp.height)*/
	                        initCanvas();
                        });


                        this.initCanvas();
}


