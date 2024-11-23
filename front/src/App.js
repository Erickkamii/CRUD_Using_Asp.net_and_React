import React, { useState, useEffect } from "react";
import { Table, Button, Modal, Input, Row, Col, Form } from "antd";
import axios from "axios";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

const App = () => {
    const [data, setData] = useState([]);
    const [visible, setVisible] = useState(false);
    const [editingProduct, setEditingProduct] = useState(null);

    const [form] = Form.useForm();

    useEffect(() => {
        fetchData();
    }, []);

    const fetchData = () => {
        axios
            .get("http://localhost:5192/api/Produtos")
            .then((result) => setData(result.data))
            .catch((error) => console.error(error));
    };

    const handleEdit = (product) => {
        setEditingProduct(product);
        form.setFieldsValue(product);
        setVisible(true);
    };

    const handleDelete = (id) => {
        if (window.confirm("Confirma a exclusão?")) {
            axios
                .delete(`http://localhost:5192/api/Produtos/${id}`)
                .then(() => {
                    toast.success("Produto apagado!");
                    fetchData();
                })
                .catch((error) => toast.error(error));
        }
    };

    const handleSave = () => {
        form.validateFields().then((values) => {
            const url = editingProduct ? `http://localhost:5192/api/Produtos/${editingProduct.id}` : "http://localhost:5192/api/Produtos";
            const method = editingProduct ? "put" : "post";

            axios[method](url, values)
                .then(() => {
                    toast.success(editingProduct ? "Produto atualizado!" : "Produto adicionado!");
                    setVisible(false);
                    fetchData();
                    setEditingProduct(null);
                    form.resetFields();
                })
                .catch((error) => toast.error(error));
        });
    };

    const handleCancel = () => {
        setVisible(false);
        setEditingProduct(null);
        form.resetFields();
    };

    const columns = [
        {
            title: "Nome",
            dataIndex: "nome",
            key: "nome",
        },
        {
            title: "Preço de Custo",
            dataIndex: "precoCusto",
            key: "precoCusto",
        },
        {
            title: "Preço de Venda",
            dataIndex: "precoVenda",
            key: "precoVenda",
        },
        {
            title: "Quantidade",
            dataIndex: "quantidade",
            key: "quantidade",
        },
        {
            title: "Ações",
            key: "actions",
            render: (_, record) => (
                <>
                    <Button
                        type="primary"
                        onClick={() => handleEdit(record)}
                        style={{ marginRight: 8 }}
                    >
                        Editar
                    </Button>
                    <Button
                        type="danger"
                        onClick={() => handleDelete(record.id)}
                    >
                        Apagar
                    </Button>
                </>
            ),
        },
    ];

    return (
        <div
            style={{
                marginTop: '20px',
                marginLeft: '15px',
                marginRight: '15px',
                padding: '20px',
            }}
        >
            <ToastContainer />
            <Row gutter={16} style={{ marginBottom: 16 }}>
                <Col span={6}>
                    <Input
                        placeholder="Nome"
                        onChange={(e) => setEditingProduct({ ...editingProduct, nome: e.target.value })}
                    />
                </Col>
                <Col span={6}>
                    <Input
                        placeholder="Preço de Custo"
                        onChange={(e) => setEditingProduct({ ...editingProduct, precoCusto: e.target.value })}
                    />
                </Col>
                <Col span={6}>
                    <Input
                        placeholder="Preço de Venda"
                        onChange={(e) => setEditingProduct({ ...editingProduct, precoVenda: e.target.value })}
                    />
                </Col>
                <Col span={6}>
                    <Input
                        placeholder="Quantidade"
                        onChange={(e) => setEditingProduct({ ...editingProduct, quantidade: e.target.value })}
                    />
                </Col>
                <Col span={24} style={{ display: 'flex', justifyContent:'center'}}>
                    <Button type="primary" onClick={handleSave}>
                        Inserir
                    </Button>
                </Col>
            </Row>

            <Table
                columns={columns}
                dataSource={data}
                rowKey="id"
                style={{ marginTop: 16 }}
            />

            <Modal
                title={editingProduct ? "Editar Produto" : "Adicionar Produto"}
                visible={visible}
                onOk={handleSave}
                onCancel={handleCancel}
                okText="Salvar"
                cancelText="Cancelar"
            >
                <Form form={form} layout="vertical" initialValues={editingProduct}>
                    <Form.Item
                        name="nome"
                        label="Nome"
                        rules={[{ required: true, message: "Por favor, insira o nome!" }]}
                    >
                        <Input />
                    </Form.Item>
                    <Form.Item
                        name="precoCusto"
                        label="Preço de Custo"
                        rules={[{ required: true, message: "Por favor, insira o preço de custo!" }]}
                    >
                        <Input />
                    </Form.Item>
                    <Form.Item
                        name="precoVenda"
                        label="Preço de Venda"
                        rules={[{ required: true, message: "Por favor, insira o preço de venda!" }]}
                    >
                        <Input />
                    </Form.Item>
                    <Form.Item
                        name="quantidade"
                        label="Quantidade"
                        rules={[{ required: true, message: "Por favor, insira a quantidade!" }]}
                    >
                        <Input />
                    </Form.Item>
                </Form>
            </Modal>
        </div>
    );
};

export default App;
