import React, { useState, useEffect } from 'react';
import {
  Container,
  Box,
  Typography,
  CircularProgress,
  Alert,
  Snackbar,
} from '@mui/material';
import PatientList from './components/PatientList';
import OrdersDialog from './components/OrdersDialog';
import { patientApi } from './services/api';
import './App.css';

function App() {
  const [patients, setPatients] = useState([]);
  const [selectedPatient, setSelectedPatient] = useState(null);
  const [dialogOpen, setDialogOpen] = useState(false);
  const [loading, setLoading] = useState(true);
  const [snackbar, setSnackbar] = useState({
    open: false,
    message: '',
    severity: 'success',
  });

  // 載入病患資料
  const loadPatients = async () => {
    try {
      setLoading(true);
      const response = await patientApi.getAllPatients();
      if (response.code === 200 && response.data) {
        setPatients(response.data.patients || []);
      }
    } catch (error) {
      showSnackbar('載入病患資料失敗', 'error');
      console.error('Error loading patients:', error);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    loadPatients();
  }, []);

  // 顯示通知
  const showSnackbar = (message, severity = 'success') => {
    setSnackbar({ open: true, message, severity });
  };

  // 關閉通知
  const handleCloseSnackbar = () => {
    setSnackbar({ ...snackbar, open: false });
  };

  // 點擊病患
  const handlePatientClick = (patient) => {
    setSelectedPatient(patient);
    setDialogOpen(true);
  };

  // 關閉對話框
  const handleCloseDialog = () => {
    setDialogOpen(false);
    setSelectedPatient(null);
  };

  // 新增醫囑
  const handleAddOrder = async (patientId, message) => {
    try {
      const response = await patientApi.addOrderToPatient(patientId, message);
      if (response.code === 200) {
        showSnackbar('醫囑新增成功', 'success');
        await loadPatients();
        // 更新選中的病患資料
        const updatedPatients = await patientApi.getAllPatients();
        if (updatedPatients.code === 200 && updatedPatients.data) {
          const updatedPatient = updatedPatients.data.patients.find(
            (p) => p.patientId === patientId
          );
          setSelectedPatient(updatedPatient);
        }
      }
    } catch (error) {
      showSnackbar('新增醫囑失敗', 'error');
      console.error('Error adding order:', error);
    }
  };

  // 更新醫囑
  const handleUpdateOrder = async (patientId, orderId, message) => {
    try {
      const response = await patientApi.modifyPatientOrder(
        patientId,
        orderId,
        message
      );
      if (response.code === 200) {
        showSnackbar('醫囑更新成功', 'success');
        await loadPatients();
        // 更新選中的病患資料
        const updatedPatients = await patientApi.getAllPatients();
        if (updatedPatients.code === 200 && updatedPatients.data) {
          const updatedPatient = updatedPatients.data.patients.find(
            (p) => p.patientId === patientId
          );
          setSelectedPatient(updatedPatient);
        }
      }
    } catch (error) {
      showSnackbar('更新醫囑失敗', 'error');
      console.error('Error updating order:', error);
    }
  };

  return (
    <Box className="App">
      <Container maxWidth="md" sx={{ py: 4 }}>
        <Box mb={4}>
          <Typography variant="h3" component="h1" gutterBottom align="center" sx={{ color: 'white' }}>
            病患管理系統
          </Typography>
          <Typography variant="subtitle1" align="center" sx={{ color: 'rgba(255, 255, 255, 0.9)' }}>
            點擊病患查看醫囑記錄
          </Typography>
        </Box>

        {loading ? (
          <Box display="flex" justifyContent="center" py={4}>
            <CircularProgress sx={{ color: 'white' }} />
          </Box>
        ) : patients.length > 0 ? (
          <PatientList patients={patients} onPatientClick={handlePatientClick} />
        ) : (
          <Alert severity="info">目前沒有病患資料</Alert>
        )}

        <OrdersDialog
          open={dialogOpen}
          onClose={handleCloseDialog}
          patient={selectedPatient}
          onAddOrder={handleAddOrder}
          onUpdateOrder={handleUpdateOrder}
        />

        <Snackbar
          open={snackbar.open}
          autoHideDuration={3000}
          onClose={handleCloseSnackbar}
          anchorOrigin={{ vertical: 'bottom', horizontal: 'center' }}
        >
          <Alert
            onClose={handleCloseSnackbar}
            severity={snackbar.severity}
            sx={{ width: '100%' }}
          >
            {snackbar.message}
          </Alert>
        </Snackbar>
      </Container>
    </Box>
  );
}

export default App;
