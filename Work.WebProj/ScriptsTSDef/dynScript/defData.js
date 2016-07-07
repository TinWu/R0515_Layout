var commData;
(function (commData) {
    commData.genderData = [
        { label: '男', value: true },
        { label: '女', value: false }
    ];
    commData.fuelCategory = [
        { code: 'gas', value: '氣體', unit_all_name: 'kcal/m³', unit_short_name: 'm³' },
        { code: 'liquid', value: '液體', unit_all_name: 'kcal/L', unit_short_name: 'kL' },
        { code: 'solid', value: '固體', unit_all_name: 'kcal/kg', unit_short_name: 'kg' }
    ];
    commData.equipmentCategory = [
        { key: 1, value: '加熱爐' },
        { key: 2, value: '裂解爐' },
        { key: 3, value: '熱媒鍋爐' },
    ];
    commData.queryUseType = [
        { key: 1, value: '煙氣出口溫度年平均值' },
        { key: 2, value: '爐氣含氧體積濃度年平均值' }
    ];
})(commData || (commData = {}));
