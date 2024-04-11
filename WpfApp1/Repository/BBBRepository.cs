﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BBBRepository
    {
        private BBBEntity.BBBEntity _bbbEntity;

        public BBBRepository()
        {
            _bbbEntity = new BBBEntity.BBBEntity();
        }

        public void Save(BBBEntity.BBBEntity aaaEntity)
        {
            _bbbEntity = aaaEntity.Clone();
        }

        public BBBEntity.BBBEntity Load()
        {
            return _bbbEntity.Clone();
        }
    }
}
