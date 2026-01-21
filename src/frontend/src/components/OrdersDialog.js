import React, { useState } from 'react';
import {
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  Button,
  List,
  ListItem,
  ListItemText,
  TextField,
  IconButton,
  Box,
  Typography,
} from '@mui/material';
import AddIcon from '@mui/icons-material/Add';
import EditIcon from '@mui/icons-material/Edit';
import SaveIcon from '@mui/icons-material/Save';
import CloseIcon from '@mui/icons-material/Close';

const OrdersDialog = ({ open, onClose, patient, onAddOrder, onUpdateOrder }) => {
  const [editingOrderId, setEditingOrderId] = useState(null);
  const [editMessage, setEditMessage] = useState('');
  const [newOrderMessage, setNewOrderMessage] = useState('');
  const [isAddingOrder, setIsAddingOrder] = useState(false);

  if (!patient) return null;

  const handleEditClick = (order) => {
    setEditingOrderId(order.orderId);
    setEditMessage(order.message);
  };

  const handleSaveEdit = async () => {
    if (editMessage.trim()) {
      await onUpdateOrder(patient.patientId, editingOrderId, editMessage);
      setEditingOrderId(null);
      setEditMessage('');
    }
  };

  const handleCancelEdit = () => {
    setEditingOrderId(null);
    setEditMessage('');
  };

  const handleAddOrder = async () => {
    if (newOrderMessage.trim()) {
      await onAddOrder(patient.patientId, newOrderMessage);
      setNewOrderMessage('');
      setIsAddingOrder(false);
    }
  };

  const handleCancelAdd = () => {
    setNewOrderMessage('');
    setIsAddingOrder(false);
  };

  return (
    <Dialog open={open} onClose={onClose} maxWidth="md" fullWidth>
      <DialogTitle>
        <Box display="flex" justifyContent="space-between" alignItems="center">
          <Typography variant="h6">
            {patient.name} 的醫囑
          </Typography>
          <IconButton
            color="primary"
            onClick={() => setIsAddingOrder(true)}
            disabled={isAddingOrder}
          >
            <AddIcon />
          </IconButton>
        </Box>
      </DialogTitle>
      <DialogContent dividers>
        {isAddingOrder && (
          <Box mb={2} p={2} sx={{ backgroundColor: '#f5f5f5', borderRadius: 1 }}>
            <TextField
              fullWidth
              label="新增醫囑"
              value={newOrderMessage}
              onChange={(e) => setNewOrderMessage(e.target.value)}
              multiline
              rows={2}
              variant="outlined"
              autoFocus
            />
            <Box mt={1} display="flex" justifyContent="flex-end" gap={1}>
              <Button
                size="small"
                variant="outlined"
                onClick={handleCancelAdd}
              >
                取消
              </Button>
              <Button
                size="small"
                variant="contained"
                onClick={handleAddOrder}
                startIcon={<SaveIcon />}
              >
                儲存
              </Button>
            </Box>
          </Box>
        )}

        {patient.orders && patient.orders.length > 0 ? (
          <List>
            {patient.orders.map((order) => (
              <ListItem
                key={order.orderId}
                sx={{
                  border: '1px solid #e0e0e0',
                  borderRadius: 1,
                  mb: 1,
                  backgroundColor: editingOrderId === order.orderId ? '#f5f5f5' : 'white',
                }}
              >
                {editingOrderId === order.orderId ? (
                  <Box width="100%">
                    <TextField
                      fullWidth
                      value={editMessage}
                      onChange={(e) => setEditMessage(e.target.value)}
                      multiline
                      rows={2}
                      variant="outlined"
                      size="small"
                    />
                    <Box mt={1} display="flex" justifyContent="flex-end" gap={1}>
                      <Button
                        size="small"
                        variant="outlined"
                        onClick={handleCancelEdit}
                        startIcon={<CloseIcon />}
                      >
                        取消
                      </Button>
                      <Button
                        size="small"
                        variant="contained"
                        onClick={handleSaveEdit}
                        startIcon={<SaveIcon />}
                      >
                        儲存
                      </Button>
                    </Box>
                  </Box>
                ) : (
                  <>
                    <ListItemText
                      primary={order.message}
                      secondary={`醫囑 ID: ${order.orderId}`}
                    />
                    <IconButton
                      edge="end"
                      onClick={() => handleEditClick(order)}
                    >
                      <EditIcon />
                    </IconButton>
                  </>
                )}
              </ListItem>
            ))}
          </List>
        ) : (
          <Box textAlign="center" py={4}>
            <Typography color="textSecondary">
              目前沒有醫囑記錄
            </Typography>
          </Box>
        )}
      </DialogContent>
      <DialogActions>
        <Button onClick={onClose}>關閉</Button>
      </DialogActions>
    </Dialog>
  );
};

export default OrdersDialog;
