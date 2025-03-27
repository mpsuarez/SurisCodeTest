import axios from "axios";
import { useFormik } from "formik";
import { useEffect, useState } from "react";
import { Button, Form, InputGroup, Dropdown } from "react-bootstrap";
import { useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";
import { toast } from "react-toastify";
import * as Yup from "yup";

interface Service {
    id: string;
    name: string;
}

interface WorkingTime {
    id: string;
    workingTime: {
        time: string;
    };
}

export default function Reserve() {
    const navigate = useNavigate();

    const [isSubmitting, setIsSubmitting] = useState(false);

    const [services, setServices] = useState<Service[]>([]);
    const [serviceWorkingTimes, setServiceWorkingTimes] = useState<
        WorkingTime[]
    >([]);
    const [showTimesDropdown, setShowTimesDropdown] = useState(false);

    const { handleChange, values, handleSubmit, touched, errors } = useFormik({
        initialValues: {
            Service: "",
            Date: "",
            Time: "",
            Client: "",
        },
        validationSchema: Yup.object({
            Service: Yup.string().required("Required"),
            Date: Yup.date().required("Required"),
            Time: Yup.string().required("Required"),
            Client: Yup.string().required("Required"),
        }),
        onSubmit: (values) => {
            submit(values);
        },
    });

    const submit = (values: any) => {
        setIsSubmitting(true);
        axios
            .post(`${import.meta.env.VITE_SurisCodeTest_URL}Reserve`, {
                ServiceId: values.Service,
                Date: values.Date,
                ServiceWorkingTimeId: values.Time,
                Client: values.Client,
            })
            .then((event) => {
                console.log(event);
                if (event.data === "") {
                    toast.success("Reserva creada");
                    navigate(`/ReserveList`);
                } else {
                    toast.error(event.data);
                }
            })
            .catch((error) => {
                toast.error("ha ocurrido un error");
            })
            .finally(() => {
                setIsSubmitting(false);
            });
    };

    useEffect(() => {
        axios
            .get(`${import.meta.env.VITE_SurisCodeTest_URL}Services`)
            .then((response) => {
                setServices(response.data);
            });
    }, []);

    useEffect(() => {
        if (values.Service) {
            axios
                .get(
                    `${import.meta.env.VITE_SurisCodeTest_URL}ServiceWorkingTime/${values.Service}/GetServiceWorkingTimesByServiceId`
                )
                .then((response) => {
                    setServiceWorkingTimes(response.data);
                });
        }
    }, [values.Service]);

    return (
        <div className="container-fluid ">
            <div className="row">
                <div className="col-6 mx-auto">
                    <div className="card">
                        <div className="card-header">
                            <h3 className="card-title">Nueva reserva</h3>
                        </div>
                        <form onSubmit={handleSubmit}>
                            <div className="card-body">
                                <label htmlFor="ServiceId">Servicio</label>

                                <InputGroup className="mb-3">
                                    <Form.Control
                                        as={Form.Select}
                                        id="ServiceId"
                                        name="ServiceId"
                                        type="text"
                                        placeholder="Servicio"
                                        onChange={(e) => {
                                            values.Service = e.target.value;
                                            values.Time = "";
                                            handleChange(e);
                                            setShowTimesDropdown(
                                                e.target.value !== ""
                                            );
                                        }}
                                        value={values.Service}
                                        isValid={
                                            touched.Service && !errors.Service
                                        }
                                        isInvalid={
                                            touched.Service && !!errors.Service
                                        }
                                    >
                                        <option value="">Select...</option>
                                        {services.map((services) => (
                                            <option
                                                key={services.id}
                                                value={services.id}
                                            >
                                                {services.name}
                                            </option>
                                        ))}
                                    </Form.Control>
                                    {touched.Service && errors.Service ? (
                                        <Form.Control.Feedback type="invalid">
                                            {errors.Service}
                                        </Form.Control.Feedback>
                                    ) : null}
                                </InputGroup>
                                <label htmlFor="Date">Fecha</label>
                                <InputGroup className="mb-3">
                                    <Form.Control
                                        id="Date"
                                        name="Date"
                                        type="date"
                                        placeholder="Fecha"
                                        onChange={handleChange}
                                        value={values.Date}
                                        isValid={touched.Date && !errors.Date}
                                        isInvalid={
                                            touched.Date && !!errors.Date
                                        }
                                    />
                                    {touched.Date && errors.Date ? (
                                        <Form.Control.Feedback type="invalid">
                                            {errors.Date}
                                        </Form.Control.Feedback>
                                    ) : null}
                                </InputGroup>
                                {showTimesDropdown && (
                                    <>
                                        <label htmlFor="Time">Horario</label>
                                        <InputGroup className="mb-3">
                                            <Form.Control
                                                as={Form.Select}
                                                id="ServiceWorkingTimeId"
                                                name="ServiceWorkingTimeId"
                                                type="text"
                                                placeholder="Display Name"
                                                onChange={(e) => {
                                                    values.Time =
                                                        e.target.value;
                                                    handleChange(e);
                                                }}
                                                value={values.Time}
                                                isValid={
                                                    touched.Time && !errors.Time
                                                }
                                                isInvalid={
                                                    touched.Time &&
                                                    !!errors.Time
                                                }
                                            >
                                                <option value="">
                                                    Select...
                                                </option>
                                                {serviceWorkingTimes.map(
                                                    (serviceWorkingTime) => (
                                                        <option
                                                            key={
                                                                serviceWorkingTime.id
                                                            }
                                                            value={
                                                                serviceWorkingTime.id
                                                            }
                                                        >
                                                            {
                                                                serviceWorkingTime
                                                                    .workingTime
                                                                    .time
                                                            }
                                                        </option>
                                                    )
                                                )}
                                            </Form.Control>
                                            {touched.Time && errors.Time ? (
                                                <Form.Control.Feedback type="invalid">
                                                    {errors.Time}
                                                </Form.Control.Feedback>
                                            ) : null}
                                        </InputGroup>
                                    </>
                                )}
                                <label htmlFor="Client">Cliente</label>
                                <InputGroup className="mb-3">
                                    <Form.Control
                                        id="Client"
                                        name="Client"
                                        type="text"
                                        placeholder="Name"
                                        onChange={handleChange}
                                        value={values.Client}
                                        isValid={
                                            touched.Client && !errors.Client
                                        }
                                        isInvalid={
                                            touched.Client && !!errors.Client
                                        }
                                    />
                                    {touched.Client && errors.Client ? (
                                        <Form.Control.Feedback type="invalid">
                                            {errors.Client}
                                        </Form.Control.Feedback>
                                    ) : null}
                                </InputGroup>
                            </div>
                            <div className="card-footer">
                                <Button
                                    type="button"
                                    disabled={isSubmitting}
                                    className="btn btn-danger"
                                    onClick={() => navigate("/ReserveList")}
                                >
                                    Cancel
                                </Button>
                                <Button
                                    type="submit"
                                    disabled={isSubmitting}
                                    className="btn btn-success float-right"
                                    onClick={handleSubmit as any}
                                >
                                    Nuevo
                                </Button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    );
}
