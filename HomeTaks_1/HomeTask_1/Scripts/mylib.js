function loadTables() {
    select_tbl_listener("tableUsers", fill_card);
}

function getHandler(tbl, n, func) {
    return function () {
        if (tbl.selectedIndex !== undefined)
            tbl.rows[tbl.selectedIndex].style.background = "#F4A460";
        tbl.selectedIndex = n;
        tbl.selection = tbl.rows[n];
        tbl.rows[n].style.background = "#F4A460";
        document.getElementById('addUser').style.display = "block";
        func();
    };
}

function fill_card() {
    var tbl = document.getElementById('tableUsers');
    var row = tbl.selection;
    document.getElementById('UserName').value = row.cells[1].innerHTML;
    document.getElementById('IdInput').value = row.cells[0].innerHTML;
}

function select_tbl_listener(tbl, func) {
    var o = document.getElementById(tbl);
    
    o.click = "one";
    o.func = func;
    var l = o.rows.length;
    for (var i = 0; i < l; i++) {
        o.rows[i].onclick = getHandler(o, i, func);
    }
}

function select_default_tbl_listener(tbl, func) {
    var o = document.getElementById(tbl);
    o.click = "double";
    o.func = func;
    var l = o.rows.length;
    for (var i = 0; i < l; i++) {
        o.rows[i].ondblclick = getHandler(o, i, func);
        o.rows[i].onclick = getHandler(o, i, nop);
    }
}

function traverse_listener(w, func) {
    var o = document.getElementById(w);
    o.onkeyup = function (e) {
        if (e.keyCode == 13)
            func();
    };
}