import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class FechDeprts extends Component {
    constructor(props) {
        super(props);
        this.state = { depts: [], loading:true}
    }

    componentDidMount() {
        this.populateDeptstData()


    }
    async populateDeptstData() {
        const response = await fetch('api/daprtsapi');
        const data = await response.json();
        this.setState({ depts:data, loading:false});
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderDeptsTable(this.state.depts);
        return (
            <div>
                <h1 id="tableLable">Deptartmets</h1>
                <p>This componets fetches Depts  data from the  server</p>
                <p>
                    <Link to="/adddept">Create New Dept</Link>
                </p>
                {contents}
            </div>
        )
    }
    renderDeptsTable(depts) {
        return (

            <table className="table table-striped" aria-labelledby="tableLable">
                <thead>
                    <tr>
                        <th></th>
                        <th>Dept #</th>
                        <th>Name</th>
                        <th>Location</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {depts.map(dept =>
                        <tr key={dept.departNumber}>
                            <td></td>
                            <td>{dept.departNumber}</td>
                            <td>{dept.departname}</td>
                            <td>{dept.locations}</td>
                            <td>
                                <button className="btn btn-success" onClick={(id) => this.handleEdit(dept.departNumber)} >Edit</button>&nbsp;
                                <button className="btn btn-danger" onClick={(id) => this.handleDelete(dept.departNumber)} >Delete</button>&nbsp;

                            </td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }
    handleEdit(id) {
        this.props.history.push("depts/edit/" + id);

    }

    handleDelete(id) {
        if (!window.confirm("Do you want to Delete Dept with DeptNunber" + id)) {
            return;
        }
        else {
            fetch('/api/daprtsapi/' + id, { method: 'delete' })
                .then(data => {
                    this.setState({
                        data: this.state.depts.filter((rec) => {
                            return rec.departNumber != id;
                        })
                    });
                });
        }
      
    }
}