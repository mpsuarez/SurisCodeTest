import DataTable from "datatables.net-react";
import DT from "datatables.net-bs5";
import { Link } from "react-router-dom";
import { useEffect, useState } from "react";
import axios from "axios";
import { use } from "chai";

DataTable.use(DT);

export default function ReserveList() {
    const [listDataTableData, setListDataTableData] = useState([]);

    const listDatatableColumns = [
        {
            title: "Servicio",
            name: "Servicio",
            data: "serviceWorkingTime.service.name",
        },
        { title: "Fecha", name: "Fecha", data: "date" },
        {
            title: "Horario",
            name: "Horario",
            data: "serviceWorkingTime.workingTime.time",
        },
        {
            title: "Cliente",
            name: "Cliente",
            data: "client",
        },
    ];

    useEffect(() => {
        axios
            .get(`${import.meta.env.VITE_SurisCodeTest_URL}Reserve/GetForList`)
            .then((response) => {
                setListDataTableData(response.data);
            });
    }, []);

    return (
        <div className="container-fluid ">
            <div className="row">
                <div className="col-12 mx-auto">
                    <div className="card">
                        <div className="card-header">
                            <h3 className="card-title">Lista de Recervas</h3>
                        </div>
                        <div className="card-body">
                            <DataTable
                                data={listDataTableData}
                                columns={listDatatableColumns}
                                className="table table-striped table-hover text-center"
                            />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}
