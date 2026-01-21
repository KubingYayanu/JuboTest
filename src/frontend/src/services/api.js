import axios from 'axios';

const API_BASE_URL = 'http://localhost:18886/api/v1';

const api = axios.create({
  baseURL: API_BASE_URL,
  headers: {
    'Content-Type': 'application/json',
  },
});

export const patientApi = {
  // 取得所有病患列表
  getAllPatients: async () => {
    try {
      const response = await api.get('/patient');
      return response.data;
    } catch (error) {
      console.error('Error fetching patients:', error);
      throw error;
    }
  },

  // 新增醫囑到病患
  addOrderToPatient: async (patientId, message) => {
    try {
      const response = await api.post(`/patient/${patientId}/order/add`, {
        message,
      });
      return response.data;
    } catch (error) {
      console.error('Error adding order:', error);
      throw error;
    }
  },

  // 修改病患醫囑
  modifyPatientOrder: async (patientId, orderId, message) => {
    try {
      const response = await api.patch(
        `/patient/${patientId}/order/${orderId}/modify`,
        {
          message,
        }
      );
      return response.data;
    } catch (error) {
      console.error('Error modifying order:', error);
      throw error;
    }
  },
};
