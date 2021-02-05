import React, { Component } from 'react';
import { Link } from 'react-router-dom';


export class Dept {
    constructor() {
        this.departNumber = 0;
        this.departname = "";
        this.locations = "";
    }

}

export class AddDept extends Component {
    constructor(props) {
        super(props);
        this.state = { title: "", dept: new Dept, loading: true };
        this.initialize();

        this.handleSave = this.handleSave.bind(this);
        this.handleCancel = this.handleCancel.bind(this);

    }

    async initialize() {
        var departNumber = this.props.match.params["departNumber"];

        if (departNumber > 0) {
            const response = await fetch('api/daprtsapi/' + departNumber);
            const data = await response.json();
            this.setState({ title: "Edit", dept: data, loading: false });
        }
        else {
            this.state = { title: "Create", dept: new Dept, loading: false };
        }
    }
    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderCreateForm();
        return <div>
            <h1>{this.state.title}</h1>
            <h3>Department</h3>
            <hr />
            {contents}
        </div>;
    };

    handleSave(event) {
        event.preventDefault();

        const data = new FormData(event.target);
        if (this.state.dept.departNumber) {
            var response1 = fetch('api/daprtsapi/' + this.state.dept.departNumber, { method: 'PUT', body: data });
            this.props.history.push("/fetch-depts");
        }
        else {
            var response2= fetch('api/daprtsapi/', { method: 'POST', body: data });
            this.props.history.push("/fetch-depts");

        }
    }
    handleCancel(event) {

        event.preventDefault();
        this.props.history.push("/fetch-depts");


    }

    renderCreateForm() {
        return (
            <form onSubmit={this.handleSave}>
                <div className="form-group row">
                    <input type="hidden" name="departNumber" value={this.state.dept.departNumber} />
                </div>
                <div className="form-group row">
                    <label className="control-label col-md-12" ntmlFor="departname">Name</label>
                    <div className="col-md-4">
                        <input type="text" name="Departname" defaultValue={this.state.dept.departname} className="form-control" required />
                    </div>
                </div>
                <div className="form-group row">
                    <label className="control-label col-md-12" ntmlFor="locations">Locations</label>
                    <div className="col-md-4">
                        <input type="text" name="locations" defaultValue={this.state.dept.locations} className="form-control" required />
                    </div>
                </div>
                <div className="form-group">
                    <button type="submit" className="btn btn-success">Save</button>
                    <button className="btn btn-danger" onClick={this.handleCancel}>Cancel</button>
                </div>
            </form>
        );
    };


}