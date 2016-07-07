var GridButtonModify = React.createClass({
	getInitialState: function() {  
		return { 
		};  
	},
	onClick:function(e){
		this.props.modify();
	},
	render:function(){
		return (
			<button type="button" className="btn-link btn-lg" onClick={this.onClick}><i className="fa-pencil"></i></button>
			);
	}
});

var GridCheckDel = React.createClass({
	getInitialState: function() {  
		return { 
		};  
	},
	onChange:function(e){
		this.props.delCheck(this.props.iKey,this.props.chd);
	},
	render:function(){
		return (
			<label className="cbox">
				<input type="checkbox" checked={this.props.chd} onChange={this.onChange} />
				<i className="fa-check"></i>
			</label>
			);
	}
});

var GridNavPage = React.createClass({
	getInitialState: function() {  
		return {
		};  
	},
	firstPage:function(){
		this.props.onQueryGridData(1);
	},
	lastPage:function(){
		this.props.onQueryGridData(this.props.TotalPage);
	},
	nextPage:function(){
		if(this.props.NowPage < this.props.TotalPage){
			this.props.onQueryGridData(this.props.NowPage + 1);
		}
	},
	prvePage:function(){
		if(this.props.NowPage > 1){
			this.props.onQueryGridData(this.props.NowPage - 1);
		}
	},
	jumpPage:function(){

	},
	render:function(){
		var oper = null;

		oper = (
			<div className="table-footer">
			    <div className="pull-left">
			        <button className="btn-link text-success"
			                type="button"
			                onClick={this.props.InsertType}>
			            <i className="fa-plus-circle"></i> 新增
			        </button>
			        <button className="btn-link text-danger" type="button"
			                onClick={this.props.deleteSubmit}>
			            <i className="fa-trash-o"></i> 刪除
			        </button>
			    </div>
			    <small className="pull-right">第{this.props.StartCount}-{this.props.EndCount}筆，共{this.props.RecordCount}筆</small>

			    <ul className="pager">
			        <li>
			            <a href="#" title="移至第一頁" tabIndex="-1" onClick={this.firstPage}>
			                <i className="fa-angle-double-left"></i>
			            </a>
			        </li> { } 
			        <li>
			            <a href="#" title="上一頁" tabIndex="-1" onClick={this.prvePage}>
			                <i className="fa-angle-left"></i>
			            </a>
			        </li> { } 
			        <li className="form-inline">
			            <div className="form-group">
			                <label>第</label>
			                {' '}
			                <input className="form-control" type="number" min="1" tabIndex="-1" value={this.props.NowPage}
			                       onChange={this.jumpPage} />
			                {' '}
			                <label>頁，共{this.props.TotalPage}頁</label>
			            </div>
			        </li> { } 
			        <li>
			            <a href="#" title="@Resources.Res.NextPage" tabIndex="-1" onClick={this.nextPage}>
			                <i className="fa-angle-right"></i>
			            </a>
			        </li> { } 
			        <li>
			            <a href="#" title="移至最後一頁" tabIndex="-1" onClick={this.lastPage}>
			                <i className="fa-angle-double-right"></i>
			            </a>
			        </li>
			    </ul>
			</div>
		);

		return oper;
	}
});

//日期輸入元件
var InputDate = React.createClass({
	mixins: [React.addons.LinkedStateMixin], 
	getInitialState: function() {  
		return { 
		};  
	},
	getDefaultProps:function(){
		return{	
			value:null,
			onChange:null,
			name:null
		};
	},
	componentDidMount:function(){
		$('#' + this.props.id).datetimepicker(
			{
				format:'YYYY-MM-DD',
				icons: {
					previous: "fa-angle-left",
	                next: "fa-angle-right"
				}
			}).on('dp.change',function(e){
				//console.log('dp.change',this.props.name,e.target.value);
				this.props.onChange(this.props.name,e);
			}.bind(this));
	},
	componentDidUpdate:function(prevProps, prevState){
	},
	componentWillUnmount:function(){
		//console.log('dp.change dismiss');
	},
	onChange:function(e){
		this.props.onChange(this.props.name,e);
	},
	render:function(){
		//.bind('活動日期')
		return (
				<input 
					type="date" 
					className="form-control datetimepicker"
					id={this.props.id}
					name={this.props.name}
					value={this.props.value!=undefined ? moment(this.props.value).format('YYYY-MM-DD'):''}
					onChange={this.onChange}
					required />
			);
		}
});

//Image共用元件
var ImgList = React.createClass({
	getInitialState: function() {  
		return { 
		};  
	},
	getDefaultProps:function(){
		//預設值
		return{	
			SetClass:null,
			NoImagePath:gb_approot + 'Content/images/Activities/no_pic.jpg'
		};
	},
	render:function(){	
		
		if(this.props.imgsrc!=undefined){
			return <img src={this.props.imgsrc} className={this.props.SetClass} />;
		}else{
			return <img src={this.props.NoImagePath} />;
		}
	}
});