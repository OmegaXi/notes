_setLptPrintItems: function () {
        this._showTemplate(false);
        this._removeAllItems(this._getPrintItemCheckboxGroup());
        this._getPrintItemSelectPanel().remove(this._getPrintItemCheckboxGroup());
        this._getPrintItemSelectPanel().add(this._getGrid4Lpt());
        this._getPrintItemSelectPanel().doLayout();
    },
	_getGrid4Lpt : function () {
        var sm = new Ext.grid.CheckboxSelectionModel();
        var gridId = this.getId() + "-" + "grid";
        var store = new com.oocl.ir4.sps.framework.web.js.commonUI.data.Store(
            {
                proxy: new Ext.data.MemoryProxy(),
                root: 'data',
                reader: new com.oocl.ir4.sps.framework.web.js.commonUI.data.JsonReader(
                    {
                        idProperty: 'clientKey',
                        fields: ['serialNum','notificationType', 'width'],
                        pageSize: 20,
                        remoteSort: false
                    }),
                writer: new com.oocl.ir4.sps.framework.web.js.commonUI.data.JsonWriter(),
                autoSave: false
            });
        for(var i=0;i<26;i++){
            var rec = new (store.recordType)();
            rec.set('serialNum', i+1);
            rec.set('notificationType', '');
            rec.set('width', '')
            store.add(rec);
        }
        var comboContent = {
            '<%=index2+1%>': '序',
            '<%=leg.LoadSeq%>': '装车顺序',
            '<%=leg.SrNo%>': '订单号',
            '<%=leg.SrNoChangeLine%>': '货号',
            '<%=leg.SrCreateTime%>': '开单日期',
            '<%=leg.paymentMethod%>': '结算方式',
            '<%=leg.paymentMethodChangeLine%>': '付款方式',
            '<%=leg.remark%>': '备注',
            '<%=leg.CustomerRef%>': '客户参考号',
            '<%=leg.CustomerRef_1%>': '客户参考号1',
            '<%=leg.DeliveryType4HZWL%>': '交货方式',
            '<%=leg.DeliveryCity4HZWL%>': '到达站',
            '<%=leg.DeliveryAddress4HZWL%>': '收货地址',
            '<%=leg.Deliverer4HZWL%>': '收货方',
            '<%=leg.DelivererPhone4HZWL%>': '收货电话',
            '<%=leg.DeliveryTime%>': '收货时间',
            '<%=leg.CargoName%>': '货名',
            '<%=leg.PackingUnit%>': '包装',
            '<%=leg.Quantity%>': '件数',
            '<%=leg.Volume%>': '体积M³',
            '<%=leg.Weight%>': '重量T',
            '<%=leg.PickupParty4HZWL%>': '发货方',
            '<%=leg.PickuperPhone4HZWL%>': '联系电话',
            '<%=leg.number%>': '回单',
            '<%=leg.CustomerName%>': '客户',
            '<%=leg.CollectAmount%>': '到付(元)' //26
        };
        var numberContent = {
            '1': '1',
            '2': '2',
            '3': '3',
            '4': '4',
            '5': '5',
            '6': '6',
            '7': '7',
            '8': '8',
            '9': '9',
            '10': '10',
            '11': '11',
            '12': '12',
            '13': '13',
            '14': '14',
            '15': '15',
            '16': '16',
            '17': '17',
            '18': '18',
            '19': '19',
            '20': '20',
            '21': '21',
            '22': '22',
            '23': '23',
            '24': '24',
            '25': '25',
            '26': '26',
        };
        var grid = {
            tbar: [this._getUploadDataButton()],
            enableColumnResize: false,
            enableColumnMove: false,
            id: gridId,
            height: 700,
            xtype: 'batchCreateSrPastGrid',
            store: store,
            clicksToEdit: 1,
            loadMask: true,
            // autoHeight: true,
            selModel: sm,
            transModeUnique: true,
            viewConfig: {
                forceFit: true
            },
            columns: [sm,
                    {
                    header: '排序',
                    dataIndex: 'serialNum',
                    id: 'serialNum',
                    maxWidth:60,
                    sortable:false,
                    allowBlank: false,
                    sortable:false,
                    editor: this._getNumberCombo(),
                    renderer: function (value) {
                        return numberContent[value];
                    }
                    },{
                    header: '对应关系',
                    dataIndex: 'notificationType',
                    id: 'notificationType',
                    allowBlank: false,
                    maxWidth:200,
                    sortable:false,
                    editor: this._getNotificationTypeCombo(),
                    renderer: function (value) {
                        return comboContent[value];
                    }
                    },{
                        header: '宽度',
                        dataIndex: 'width',
                        id: 'width',
                        maxWidth:150,
                        sortable:false,
                        allowBlank: false,
                        editor: {
                            maxWidth:200,
                            xtype: 'numberfield',
                            allowBlank: false
                        }
                    }]
        };
        this._getGrid4Lpt = function () {
            return this.findById(gridId);
        };
        return grid;
    },
    _getUploadDataButton: function(){
        var id = this.getId() + 'getUpLoadDataId';
        var button = {
            id: id,
            xtype: 'highlightButton',
            text: '调整装载单',
            // handler: Ext.createDelegate(this._getupLoad(), this),
            handler: Ext.createDelegate(function () {
                this.getUpLoad(this._getGrid4Lpt());
            }, this),
            style: 'margin-left:30px;',
            tooltip: '调整装载单的表格的各项数据，包括是否显示，排序以及在页面中的所占宽度'
        };
        this._getUploadDataButton = function () {
            return Ext.getCmp(id);
        };
        return button;
    },
    getUpLoad: function (grid) {
        var selections = grid.getSelectionModel().getSelections();
        var serialNum = [];
        var notificationType = [];
        var width = [];
        var change2name = function (note) {
            switch(note)
            {
                case '<%=index2+1%>':
                    return '序';
                    break;
                case '<%=leg.LoadSeq%>':
                    return '装车顺序';
                    break;
                case '<%=leg.SrNo%>':
                    return '订单号';
                    break;
                case '<%=leg.SrNoChangeLine%>':
                    return '货号';
                    break;
                case '<%=leg.SrCreateTime%>':
                    return '开单日期';
                    break;
                case '<%=leg.paymentMethod%>':
                    return '结算方式';
                    break;
                case '<%=leg.paymentMethodChangeLine%>':
                    return '付款方式';
                    break;
                case '<%=leg.remark%>':
                    return '备注';
                    break;
                case '<%=leg.CustomerRef%>':
                    return '客户参考号';
                    break;
                case '<%=leg.CustomerRef_1%>':
                    return '客户参考号1';
                    break;
                case '<%=leg.DeliveryType4HZWL%>':
                    return '交货方式';
                    break;
                case '<%=leg.DeliveryCity4HZWL%>':
                    return '到达站';
                    break;
                case '<%=leg.DeliveryAddress4HZWL%>':
                    return '收货地址';
                    break;
                case '<%=leg.Deliverer4HZWL%>':
                    return '收货方';
                    break;
                case '<%=leg.DelivererPhone4HZWL%>':
                    return '收货电话';
                    break;
                case '<%=leg.DeliveryTime%>':
                    return '收货时间';
                    break;
                case '<%=leg.CargoName%>':
                    return '货名';
                    break;
                case '<%=leg.PackingUnit%>':
                    return '包装';
                    break;
                case '<%=leg.Quantity%>':
                    return '件数';
                    break;
                case '<%=leg.Volume%>':
                    return '体积M³';
                    break;
                case '<%=leg.Weight%>':
                    return '重量T';
                    break;
                case '<%=leg.PickupParty4HZWL%>':
                    return '发货方';
                    break;
                case '<%=leg.PickuperPhone4HZWL%>':
                    return '联系电话';
                    break;
                case '<%=leg.number%>':
                    return '回单';
                    break;
                case '<%=leg.CustomerName%>':
                    return '客户';
                    break;
                case '<%=leg.CollectAmount%>':
                    return '到付（元）';
                    break;
                default:
                    return '错误!';

            }
        };
        if (selections < 1) {
            H.messageByCode('CMM049W');
            return;
        }
        else {
            for (var i = 0;i < selections.length; i++){
                serialNum[i] = selections[i].data.serialNum;
                notificationType[i] = selections[i].data.notificationType;
                width[i] = selections[i].data.width;
            }
            var rawFile = new XMLHttpRequest();
            rawFile.open("GET", "js/com/oocl/ir4/sps/web/js/print/test.html", false);
            rawFile.onreadystatechange = function ()
            {
                if(rawFile.readyState === 4)
                {
                    if(rawFile.status === 200 || rawFile.status == 0)
                    {
                        var txt = rawFile.responseText;
                        var txtPart1 = txt.slice(0,txt.indexOf("id=\"headers\">")+13);
                        var txtPart2 = txt.slice(txt.indexOf("id=\"headers\">")+13,txt.indexOf("id=\"contents\">")+14);
                        var txtPart3 = txt.slice(txt.indexOf("id=\"contents\">")+14,txt.indexOf("id=\"footers\">")+13);
                        var txtPart4 = txt.slice(txt.indexOf("id=\"footers\">")+13);
                        var headers2insert = "";
                        var contents2insert = "";
                        var footers2insert = "";
                        for(var i=0;i<width.length;i++){
                            var width2insert = width[i];
                            var note2insert = notificationType[i];
                            var name2insert = change2name(notificationType[i]);
                            headers2insert = headers2insert + '<td width=\"' + width2insert + '\">' + name2insert + '</td>'; //添加的表格抬头
                            contents2insert = contents2insert + '<td>' + note2insert + '</td>'; //添加的中间内容
                            //添加总计
                            if(note2insert != '<%=leg.Quantity%>' && name2insert != "<%=leg.Weight%>" && name2insert != "<%=leg.Volume%>" && name2insert != "<%=leg.CollectAmount%>" && name2insert != "<%=leg.number%>"){
                                footers2insert = footers2insert + '<td></td>';
                            } else if (note2insert == '<%=leg.Quantity%>'){
                                footers2insert = footers2insert + "<td>" + "<%=loadPlan.TotalQuantity%>" + "</td>";
                            } else if (name2insert == '<%=leg.Weight%>'){
                                footers2insert = footers2insert + "<td>" + "<%=loadPlan.TotalWeight%>" + "</td>";
                            } else if (name2insert == '<%=leg.Volume%>'){
                                footers2insert = footers2insert + "<td>" + "<%=loadPlan.TotalVolumey%>" + "</td>";
                            } else if (name2insert == '<%=leg.CollectAmount%>'){
                                footers2insert = footers2insert + "<td>" + "<%=loadPlan.totalCollectAmount%>" + "</td>";
                            } else if (name2insert == '<%=leg.number%>'){
                                footers2insert = footers2insert + "<td>" + "<%=loadPlan.TotalNumber%>" + "</td>";
                            }
                        }
                        var n = txtPart1.concat(headers2insert,txtPart2,contents2insert,txtPart3,footers2insert,txtPart4);
                        alert(n);
                    }
                }
            }
            rawFile.send(null);
        }
    },
    _getNotificationTypeCombo: function () {
        var comboId = this.getId() + "-" + "notificationTypeCombo";
        var store = new Ext.data.ArrayStore({
            fields: ['valueCode', 'displayName'],
            data: [
                ['<%=index2+1%>', '序'],
                ['<%=leg.LoadSeq%>', '装车顺序'],
                ['<%=leg.SrNo%>', '订单号'],
                ['<%=leg.SrNoChangeLine%>', '货号'],
                ['<%=leg.SrCreateTime%>', '开单日期'],
                ['<%=leg.paymentMethod%>', '结算方式'],
                ['<%=leg.paymentMethodChangeLine%>', '付款方式'],
                ['<%=leg.remark%>', '备注'],
                ['<%=leg.CustomerRef%>', '客户参考号'],
                ['<%=leg.CustomerRef_1%>', '客户参考号1'],
                ['<%=leg.DeliveryType4HZWL%>', '交货方式'],
                ['<%=leg.DeliveryCity4HZWL%>', '到达站'],
                ['<%=leg.DeliveryAddress4HZWL%>', '收货地址'],
                ['<%=leg.Deliverer4HZWL%>', '收货方'],
                ['<%=leg.DelivererPhone4HZWL%>', '收货电话'],
                ['<%=leg.DeliveryTime%>', '收货时间'],
                ['<%=leg.CargoName%>', '货名'],
                ['<%=leg.PackingUnit%>', '包装'],
                ['<%=leg.Quantity%>', '件数'],
                ['<%=leg.Volume%>', '体积M³'],
                ['<%=leg.Weight%>', '重量T'],
                ['<%=leg.PickupParty4HZWL%>', '发货方'],
                ['<%=leg.PickuperPhone4HZWL%>', '联系电话'],
                ['<%=leg.number%>', '回单'],
                ['<%=leg.CustomerName%>', '客户'],
                ['<%=leg.CollectAmount%>', '到付(元)'] //26
            ]
        });
        var combo = {
            xtype: 'combobox',
            id: comboId,
            typeAhead: true,
            triggerAction: 'all',
            selectOnFocus: true,
            allowBlank: false,
            modal: 'local',
            store: store,
            valueField: 'valueCode',
            displayField: 'displayName',
            listeners: {
                select: Ext.createDelegate(function (combo) {
                    var records = this._getGrid4Lpt().getStore().getRange();
                    Ext.each(records, function (value) {
                        if (combo.getValue() == value.data.notificationType) {
                            H.information('一种对应关系只能匹配一次。');
                            combo.setValue('');
                        }
                    });
                }, this)
            }
        };
        this._getNotificationTypeCombo = function () {
            return this.findById(comboId);
        };
        return combo;
    },
    _getNumberCombo: function () {
        var comboId = this.getId() + "-" + "numberCombo";
        var store = new Ext.data.ArrayStore({
            fields: ['actualValue', 'displayValue'],
            data: [
                ['1', '1'], ['2', '2'], ['3', '3'], ['4', '4'], ['5', '5'], ['6', '6'],
                ['7', '7'], ['8', '8'], ['9', '9'], ['10', '10'], ['11', '11'], ['12', '12'],
                ['13', '13'], ['14', '14'], ['15', '15'], ['16', '16'], ['17', '17'], ['18', '18'],
                ['19', '19'], ['20', '20'], ['21', '21'], ['22', '22'], ['23', '23'], ['24', '24'],
                ['25', '25'], ['26', '26']
            ]
        });
        var combo = {
            xtype: 'combobox',
            id: comboId,
            typeAhead: true,
            triggerAction: 'all',
            selectOnFocus: true,
            allowBlank: false,
            modal: 'local',
            store: store,
            valueField: 'actualValue',
            displayField: 'displayValue',
            listeners: {
                select: Ext.createDelegate(function (combo) {
                    var records = this._getGrid4Lpt().getStore().getRange();
                    Ext.each(records, function (value) {
                        if (combo.getValue() == value.data.serialNum) {
                            H.information('这个序号已经出现过了!');
                            combo.setValue('');
                        }
                    });
                }, this)
            }
        };
        this._getNumberCombo = function () {
            return this.findById(comboId);
        };
        return combo;
    },