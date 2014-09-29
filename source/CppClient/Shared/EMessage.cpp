#include "StdAfx.h"
#include "EMessage.h"


EMessage::EMessage(const std::vector<char> &data) {
    this->data = data;
}

const char* EMessage::begin(void)
{
    return data.data();
}

const char* EMessage::end(void)
{
    return data.data() + data.size();
}
